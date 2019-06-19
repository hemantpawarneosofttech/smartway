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

    //var controlName = $("#applicationList option:selected").text();
    var controlName = new joint.shapes.standard.Image();
    window[a] = controlName;
    window[parent] = controlName;

    controlName.position(350, 0);
    prevParentPositionX = 150;
    prevParentPositionY = 100;
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
                //for (var i = 0; i <= response.length; i++) {
                //    leftChildJson.push(response[i]);
                //}
                DrawLeftChildGraph(currentLevel, response)

            } else {
                leftChildJson = JSON.parse(JSON.stringify(response));
                //Calling draw left childs method.
                DrawLeftChildGraph(1, leftChildJson)
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
                DrawLeftChildGraph(currentLevel, response, false)

            } else {
                databasesJson = JSON.parse(JSON.stringify(response));
                //Calling draw left childs method.
                DrawLeftChildGraph(1, databasesJson, false)
            }
        }
    });
}

function DrawLeftChildGraph(currentLevel, leftchilddata, IsSubsystem) {

    var leftChildPositionX = 0;
    var leftChildPositionY = 200;
    if (IsSubsystem) {
        if (currentLevel == 1) {
            //leftChildPositionX = leftChildPositionX;
            leftChildPositionY = 300;
        }
        //if (currentLevel == 2) {
        //    leftChildPositionY = 500;
        //    leftChildPositionX = leftChildPositionX + 250;
        //}
        if (currentLevel == 3) {
            leftChildPositionY = 800;
            leftChildPositionX = leftChildPositionX + 250;
        }
        //if (currentLevel == 4) {
        //    leftChildPositionY = 750;
        //    leftChildPositionX = leftChildPositionX + 250;
        //}
    }
    else {
        //if (currentLevel == 1) {
        //    leftChildPositionX = leftChildPositionX + 0;
        //    leftChildPositionY = 300;
        //}
        if (currentLevel == 2) {
            leftChildPositionY = 300;
            leftChildPositionX = 600;
        }
        //if (currentLevel == 3) {
        //    leftChildPositionY = 800;
        //    leftChildPositionX = leftChildPositionX + 250;
        //}
        if (currentLevel == 4) {
            leftChildPositionY = 750;
            leftChildPositionX = leftChildPositionX + 50;
        }
    }
    paper.setDimensions(paper.width, parseInt(currentHeight * 5, 10));

    //load leftchild for clicked item
    for (var i in leftchilddata) {
        if (leftchilddata[i].shapeType == "Rectangle" && leftchilddata[i].shapeType != "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[leftchilddata[i].shapeControlName] = controlName;
            controlName.resize(80, 50);

            controlName.position(leftChildPositionX, leftChildPositionY);
            leftChildPositionY = leftChildPositionY + 150;

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
                router: {
                    name: 'manhattan', args: { step: 50 }
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
            DrawLeftChildGraph(1, leftChildJson, true);
            DrawLeftChildGraph(1, databasesJson, false);
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
    //debugger
    var currentLevel = currentLevel;
    prevParentPositionY = 0;
    var currlevel = 1;
    prevParentPositionX = 200;

    var len = JsonData.length;
    paper.setDimensions(parseInt(len * 400, 10), parseInt(currentHeight * 5, 10));

    for (var i in JsonData) {
        if (JsonData[i].Level != currlevel)
            prevParentPositionX = 80;

        //set first positioning
        if (JsonData[i].Level == 1 && JsonData[i].shapeType != "Link") {
            //prevParentPositionY = 250;
            prevParentPositionX = prevParentPositionX;
            currlevel = JsonData[i].Level;
        }

        else if (JsonData[i].Level == 2 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Rectangle") {
            if (prevParentPositionY == 0) {
                prevParentPositionY = 280;
            }
            if (counter % 4 == 0) {
                prevParentPositionX = 100;
                prevParentPositionY = prevParentPositionY + 115;
                console.log(prevParentPositionY);
            }

            prevParentPositionX = prevParentPositionX + 130;
            currlevel = JsonData[i].Level;
            counter++;
        }

        //else if (JsonData[i].Level == 2 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Cylinder") {
        //    prevParentPositionY = 300;
        //    prevParentPositionX = prevParentPositionX + 250;
        //    currlevel = JsonData[i].Level;
        //}

        else if (JsonData[i].Level == 3 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Rectangle") {
            prevParentPositionY = 600;
            prevParentPositionX = prevParentPositionX + 180;
            currlevel = JsonData[i].Level;
        }

        else if (JsonData[i].Level == 4 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Rectangle") {
            prevParentPositionY = 900;
            prevParentPositionX = prevParentPositionX + 180;
            currlevel = JsonData[i].Level;
        }

        //else if (JsonData[i].Level == 4 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Cylinder") {
        //    prevParentPositionY = 900;
        //    prevParentPositionX = prevParentPositionX + 250;
        //    currlevel = JsonData[i].Level;
        //}


        if (JsonData[i].shapeType == "Rectangle" && JsonData[i].shapeType != "Link") {
            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[JsonData[i].shapeControlName] = controlName;
            controlName.resize(80, 50);
            //debugger
            controlName.position(prevParentPositionX + 150, prevParentPositionY);
            controlName.attr('root/title', 'joint.shapes.standard.Image');


            controlName.attr('label/text', JsonData[i].shapeLabel);
            if (JsonData[i].Level == 2) {
                controlName.attr('image/xlinkHref', '/Content/server.png');
            }
            else {
                controlName.attr('image/xlinkHref', '/Content/System.png');
            }
            controlName.addTo(graph);
        }

        if (JsonData[i].shapeType == "Cylinder" && JsonData[i].shapeType != "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Image();
            window[JsonData[i].shapeControlName] = controlName;
            controlName.resize(80, 50);

            controlName.position(prevParentPositionX + 150, prevParentPositionY);

            controlName.attr('root/title', 'joint.shapes.standard.Image');
            controlName.attr('label/text', JsonData[i].shapeLabel);
            controlName.attr('image/xlinkHref', '/Content/database.png');

            controlName.addTo(graph);
        }

        if (JsonData[i].shapeType == "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Link({
                source: { id: window[JsonData[i].linkSource].id },
                target: { id: window[JsonData[i].linkTarget].id },
                //router: { name: 'manhattan' },
                router: {
                    name: 'manhattan', args: { step: 50 }
                },
                connector: { name: 'rounded' },
            });
            controlName.attr('line/stroke', '#16459e');
            controlName.addTo(graph);
        }
    }

    var isApp = checkIsApplication(clickedElementName, JsonData);
    GetLeftSubsystemData(currentLevel, isApp);
    //GetDatabasesData(currentLevel, isApp);
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