var currentWidth = 3000;
var currentHeight = 800;
//var getUrl = window.location;
//var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];

var prevParentPositionX = 0, prevParentPositionY = 0;
var prevLeafPositionX = 0, prevLeafPositionY = 0;
var JsonData = {}; var clickedElementName = "";

var graph = new joint.dia.Graph;

var paper = new joint.dia.Paper({
    el: document.getElementById('myholder'),
    model: graph,
    width: 3000,
    height: 1500,
    gridSize: 10,
    drawGrid: false

});




$(document).ready(function () {
    $('#applicationList').select2({
        placeholder: 'Select'
    });
    //$("#applicationList").select2();
    $("#btnLoad").hide();
    $(".tap2").hide();
    currentWidth = 1000;
})

var parent = $("#applicationList option:selected").text();
var leftChildJson = [], databasesJson = [];

function checkIsApplication(shapeLabel, JsonData) {

    var levelData = $.grep(JsonData, function (el) {
        return el.shapeLabel == shapeLabel;
    });
    return levelData[0].IsApplication;
}


function bindData() {

    JsonData = [];
    var a = $("#applicationList option:selected").text();

    var FirstNodeJsonData = JSON.parse('{"id": 1,"shapeType": "Rectangle","shapeControlName":"' + a + '","shapeLabel": "' + a + '","linkSource": null,"linkTarget": null,"parent":null,"IsLeaf":false,"IsBase": false,"IsApplication": true,"Level": 1}');
    JsonData.push(JSON.parse(JSON.stringify(FirstNodeJsonData)));

    var controlName = new joint.shapes.standard.Image();
    window[a] = controlName;
    window[parent] = controlName;

    controlName.position(650, 0);
    controlName.resize(80, 50);

    controlName.attr('root/title', 'joint.shapes.standard.Image');
    controlName.attr('label/text', $("#applicationList option:selected").text());
    controlName.attr('image/xlinkHref', '/Content/system.png');
    controlName.addTo(graph);
}

function GetLeftSubsystemData(currentLevel, isApp) {
    if (!isApp) {
        return;
    }

    var LeftChildInputModel = {
        shapeLabel: clickedElementName,
        isApplication: isApp
    }

    $.ajax({
        url: GetSubsystemApplications,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ model: LeftChildInputModel }),
        success: function (response) {
            if (leftChildJson.length != 0) {
                DrawLeftChildGraph(response)

            } else {
                leftChildJson = JSON.parse(JSON.stringify(response));
                //Calling draw left childs method.
                DrawLeftChildGraph(leftChildJson)
            }
        }
    });
}

function GetDatabasesData(currentLevel, isApp) {

    if (!isApp) {
        return;
    }

    var LeftChildInputModel = {
        shapeLabel: clickedElementName,
        isApplication: isApp
    }

    $.ajax({
        url: GetApplicationDatabases,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ model: LeftChildInputModel }),
        success: function (response) {

            if (databasesJson.length != 0) {
                DrawRightChildGraph(response)

            } else {
                databasesJson = JSON.parse(JSON.stringify(response));
                //Calling draw right childs method.
                DrawRightChildGraph(databasesJson)
            }
        }
    });
}

var rightChildPositionY = 200;
function DrawRightChildGraph(rightChildData) {
    

    
    //load rightchilds for clicked item
    for (var i in rightChildData) {
                      
        if (rightChildData[i].shapeType == "Cylinder") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[rightChildData[i].shapeControlName] = controlName;
            controlName.resize(80, 50);

            
            controlName.position(1150, rightChildPositionY);
            rightChildPositionY = rightChildPositionY + 90;

            controlName.attr('root/title', 'joint.shapes.standard.Image');
            controlName.attr('label/text', rightChildData[i].shapeLabel);
            controlName.attr('image/xlinkHref', '/Content/Database.png');
            controlName.attr('line/stroke', '#16459e');
            controlName.addTo(graph);
        }

        if (rightChildData[i].shapeType == "Link") {
            var controlName = rightChildData[i].shapeControlName;
            controlName = new joint.shapes.standard.Link({
                source: { id: window[rightChildData[i].linkSource].id },
                target: { id: window[rightChildData[i].linkTarget].id },
                connector: { name: 'rounded' },
                router: {
                    name: 'manhattan', args: { step: 25 }
                },
                //router: {
                //    name: 'manhattan', args: {
                //       // startDirections: ['bottom'],
                //        endDirections: ['right'],
                //        step: 10,
                //    }
                //},
            });
            controlName.attr('line/stroke', '#16459e'),
                controlName.addTo(graph);
        }
    }
}



var leftChildPositionX = 150;
var leftChildPositionY = 200;

function DrawLeftChildGraph(leftchilddata) {

    if (window['currentLevel'] == 1) {
        leftChildPositionX = 150;
        leftChildPositionY = 200;
    }

    if (window['currentLevel'] == 2) {
        return;
    }

    //if (window['currentLevel'] == 3) {
    //    leftChildPositionX = leftChildPositionX;
    //    leftChildPositionY = leftChildPositionY+200;
    //}

    //if (window['currentLevel'] == 4) {
    //    return;
    //}

   
    //load leftchild for clicked item
    for (var i in leftchilddata) {
        if (leftchilddata[i].shapeType == "Rectangle" && leftchilddata[i].shapeType != "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[leftchilddata[i].shapeControlName] = controlName;
            controlName.resize(80, 50);

            controlName.position(150, leftChildPositionY);
            leftChildPositionY = leftChildPositionY + 90;

            controlName.attr('root/title', 'joint.shapes.standard.Image');
            controlName.attr('label/text', leftchilddata[i].shapeLabel);
            controlName.attr('image/xlinkHref', '/Content/Subsystem.png');
            controlName.attr('line/stroke', '#16459e');
            controlName.addTo(graph);
        }

        if (leftchilddata[i].shapeType == "Link") {
            var controlName = leftchilddata[i].shapeControlName;
            controlName = new joint.shapes.standard.Link({
                source: { id: window[leftchilddata[i].linkSource].id },
                target: { id: window[leftchilddata[i].linkTarget].id },
                connector: { name: 'rounded' },
                //router: {
                //    name: 'manhattan', args: { step: 25 }
                //},
                router: {
                    name: 'manhattan', args: {
                        //startDirections: ['left'],                        
                        //endDirections: ['left'],
                        step: 60,
                    }
                },
            });
            controlName.attr('line/stroke', '#16459e'),
                controlName.addTo(graph);
        }
    }
}

function getCompleteGraph(currentLevel, name) {

    graph.clear();
    var selectedApplication = $("#applicationList").val();

    $(".tap2").show();

    var val = JsonData.length > 1 ? 1 : null;

    var graphInputModel = {
        shapeLabel: name,
        itemid: val,
        selectedParentId: parseInt(selectedApplication)
    }

    $.ajax({
        type: 'POST',
        url: GetCompletGraph,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ graphInput: graphInputModel, inputJsonModel: JsonData }),
        success: function (resp) {
            JsonData = resp;
            drawGraph(currentLevel, JsonData);

            if (currentLevel != 2) {
                DrawLeftChildGraph(leftChildJson);
            }
        

            if (currentLevel != 2) {
                DrawRightChildGraph(databasesJson)
            }
           
            $(".tap2").hide();
        }, error: function (exp) {
            $(".tap2").hide();
        }
    });
}

function getCurrentLevel(shapeLabel, JsonData) {
    var levelData = $.grep(JsonData, function (el) {
        return el.shapeLabel == shapeLabel;
    });
    return levelData[0].Level;
}


function drawGraph(currentLevel, data) {
    var counter = 0;
    var currentLevel = currentLevel;
    prevParentPositionY = 0;
    var currlevel = 1;
    prevParentPositionX = 50;

    var len = JsonData.length;
   

    for (var i in JsonData) {
        //if (JsonData[i].Level != currlevel)
        //    prevParentPositionX = 500;

        //set first positioning
        if (JsonData[i].Level == 1 ) {     
            prevParentPositionX = 650;
            currlevel = JsonData[i].Level;
        }
        else if (JsonData[i].Level == 2  && JsonData[i].shapeType == "Rectangle") {
            if (prevParentPositionY == 0) {
                prevParentPositionY = 90;
            }
            if (counter % 6 == 0) {
                prevParentPositionX = 230;
                prevParentPositionY = prevParentPositionY + 90;
            }
            prevParentPositionX = prevParentPositionX + 120;
            currlevel = JsonData[i].Level;
            counter++;
        }
        else if (JsonData[i].Level == 3 && JsonData[i].shapeType == "Rectangle") {
            if (prevParentPositionY == 0) {
                prevParentPositionY = 100;
            }
            if (counter % 6 == 0) {
                prevParentPositionX = 228;
                prevParentPositionY = prevParentPositionY + 180;
            }
            prevParentPositionX = prevParentPositionX + 120;
            currlevel = JsonData[i].Level;
            counter++;
        }
        else if (JsonData[i].Level == 4 && JsonData[i].shapeType == "Rectangle") {            
            if (prevParentPositionY == 0) {
                prevParentPositionY = 100;
            }
            if (counter % 6 == 0) {
                prevParentPositionX = 90;
                prevParentPositionY = prevParentPositionY + 180;
            }
            prevParentPositionX = prevParentPositionX + 120;
            currlevel = JsonData[i].Level;
            counter++;
        }
        if (JsonData[i].shapeType == "Rectangle" ) {
            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[JsonData[i].shapeControlName] = controlName;
            controlName.resize(80, 50);            
            controlName.position(prevParentPositionX , prevParentPositionY);
            controlName.attr('root/title', 'joint.shapes.standard.Image');
            controlName.attr('label/text', JsonData[i].shapeLabel);
            controlName.attr('cursor', 'pointer');
        
            if (JsonData[i].Level == 2) {
                controlName.attr('image/xlinkHref', '/Content/server.png');
            }
            else {
                controlName.attr('image/xlinkHref', '/Content/System.png');
            }
            controlName.addTo(graph);
        }

      
        if (JsonData[i].shapeType == "Link") {
            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Link({
                source: { id: window[JsonData[i].linkSource].id },
                target: { id: window[JsonData[i].linkTarget].id },
                //router: { name: 'manhattan' },
                router: {
                    name: 'manhattan', args: {
                        startDirections: ['left'],
                        endDirections: ['bottom'],
                        step: 15,
                        }
                },
                connector: { name: 'rounded' },
            });
            controlName.attr('line/stroke', '#16459e');
            controlName.addTo(graph);
        }
    }

    var isApp = checkIsApplication(clickedElementName, JsonData);
    GetLeftSubsystemData(currentLevel, isApp);
    GetDatabasesData(currentLevel, isApp);
}

paper.on('cell:pointerdblclick', function (cellView) {
    if (!cellView.model.isClicked) {
        cellView.model.isClicked = true;
        if (cellView.model.isClicked) {
            var isElement = cellView.model.isElement();
            var message = (isElement ? 'Element' : 'Link') + ' clicked';
            var currentElement = cellView.model;
            clickedElementName = currentElement.attributes.attrs.label.text
            //get clicked element level
            var currentLevel = getCurrentLevel(clickedElementName, JsonData);
            if (currentLevel == 4) {
                return;
            }
            window['currentLevel'] = currentLevel;
            //call complete graph ajax request and draw graph
            getCompleteGraph(currentLevel, clickedElementName);
            cellView.model.isClicked = false;
        }
    }
});

$("#btnShow").click(function () {
    if ($("#applicationList").val() == "") {
        return;
    }
    count = 0;
    JsonData = [];
    graph.clear();
    bindData();
});

$("#btnClear").click(function () {
    JsonData = [];
    $('#applicationList').val('');
    leftChildJson = [];
    databasesJson = [];
    clickedElementName = '';
    prevParentPositionX = prevParentPositionY = 0
    graph.clear();
});