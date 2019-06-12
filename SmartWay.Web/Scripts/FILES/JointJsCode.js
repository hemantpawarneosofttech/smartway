var currentWidth = 3000;
var currentHeight = 3000;
var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
var prevPositionX = 0, prevPositionY = 0;
var firstLeafPositionX = 0;
var prevParentPositionX = 0, prevParentPositionY = 0;
var prevLeafPositionX = 0, prevLeafPositionY = 0;
var count = 0;
var levelflag = false;
var JsonDataMain = {};
var JsonData = {}; var clickedElementName = ""; oldparent = "";
var TempData = []; var JsonDataNew = {};
var graph = new joint.dia.Graph;
var paper = new joint.dia.Paper({
    el: document.getElementById('myholder'),
    model: graph,
    width: 3000,
    height: 1500,
    gridSize: 10,
    drawGrid: false
    //background: {
    //    color: 'rgba(255, 165, 0, 0.3)'
    //}
});
$('#applicationList').select2({
    placeholder: 'Select'
});
$(document).ready(function () {
    $("#applicationList").select2();
    $("#btnLoad").hide();
    $(".tap2").hide();
    currentWidth = 1000;
})

var parent = $("#applicationList option:selected").text();
var leftChildJson = [];
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
    var controlName = $("#applicationList option:selected").text();
    controlName = new joint.shapes.standard.Rectangle();
    window[a] = controlName;
    window[parent] = controlName;
    controlName.position(550, 0);
    prevParentPositionX = 200;
    prevParentPositionY = 100;
    controlName.resize(170, 60);
    controlName.attr({
        body: {
            fill: '#f7a07b',
            stroke: 'black',
            strokeWidth: 2
        },
        label: {
            text: $("#applicationList option:selected").text(),
            fill: 'black'
        }
    });
    controlName.addTo(graph);
}
function drawLeftChild(currentLevel, isApp) {
    var leftChildPositionX = 60;
    var leftChildPositionY = 200;
    if (currentLevel == 1) {
        //prevParentPositionY = 250;
        leftChildPositionX = leftChildPositionX + 0;
        leftChildPositionY = 200;
    }

    if (currentLevel == 2) {
        leftChildPositionY = 500;
        leftChildPositionX = leftChildPositionX + 250;
    }
    if (currentLevel == 3) {
        leftChildPositionY = 800;
        leftChildPositionX = leftChildPositionX + 250;
    }
    if (currentLevel == 4) {
        leftChildPositionY = 750;
        leftChildPositionX = leftChildPositionX + 250;
    }
    if (!isApp) {
        return;
    }
    var LeftChildInputModel = {
        shapeLabel: clickedElementName,
        isApplication: isApp
    }

    $.ajax({
        type: 'POST',
        //url: 'Home/GetSubsystemApplications',
        url: url1,//'@Url.Action("GetSubsystemApplications", "Home")',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ model: LeftChildInputModel }),
        //url: '/Home/GetSubsystemApplicationByName?shapeLabel=' + name + '', //name of your json file
        success: function (response) {
            var hgt = JsonData.length;
            paper.setDimensions(paper.width, parseInt(hgt * 400, 10));

            leftChildJson = JSON.parse(JSON.stringify(response));
            //load leftchild for clicked item
            for (var i in leftChildJson) {
                if (leftChildJson[i].shapeType == "Rectangle" && leftChildJson[i].shapeType != "Link") {
                    var controlName = leftChildJson[i].shapeControlName;
                    controlName = new joint.shapes.standard.Rectangle();
                    window[leftChildJson[i].shapeControlName] = controlName;

                    controlName.position(leftChildPositionX, leftChildPositionY);
                    leftChildPositionY = leftChildPositionY + 100;
                    //leftChildPositionX = leftChildPositionX + 100;
                    controlName.resize(230, 60);
                    controlName.attr({
                        body: {
                            fill: 'lightblue',
                            stroke: 'black',
                            strokeWidth: 2
                        },
                        label: {
                            text: leftChildJson[i].shapeLabel,
                            fill: 'black'
                        }
                    });
                    controlName.addTo(graph);
                }
                if (leftChildJson[i].shapeType == "Cylinder" && leftChildJson[i].shapeType != "Link") {
                    var controlName = leftChildJson[i].shapeControlName;
                    controlName = new joint.shapes.standard.Cylinder();
                    window[leftChildJson[i].shapeControlName] = controlName;
                    controlName.resize(60, 60);
                    controlName.position(leftChildPositionX, leftChildPositionY);
                    leftChildPositionY = leftChildPositionY + 100;
                    // leftChildPositionX = leftChildPositionX + 100;
                    controlName.attr('root/title', 'joint.shapes.standard.Cylinder');
                    controlName.attr('body/fill', 'lightblue');
                    controlName.attr('top/fill', 'lightblue');


                    controlName.attr('label/text', leftChildJson[i].shapeLabel);
                    controlName.topRy('10%');
                    controlName.addTo(graph);
                }
                if (leftChildJson[i].shapeType == "Link") {
                    var controlName = leftChildJson[i].shapeControlName;
                    controlName = new joint.shapes.standard.Link({
                        source: { id: window[leftChildJson[i].linkSource].id },
                        target: { id: window[leftChildJson[i].linkTarget].id },
                        //router: { name: 'manhattan' },
                        connector: { name: 'rounded' },
                        router: {
                            name: 'manhattan', args: { step: 50 }
                        },
                        //connector: { name: 'rounded' },
                    });
                    controlName.addTo(graph);
                }
            }


        }
    });
}
function getCompleteGraph(currentLevel, name) {

    //JsonDataMainNew = JSON.parse(JSON.stringify(JsonDataMain));
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
        //url: 'Home/GetCompletGraph', //name of your json file
        url: url2,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ graphInput: graphInputModel, inputJsonModel: JsonData }),
        success: function (resp) {

            $(".tap2").hide();
            //for (var i in resp) {
            //    JsonData.push(resp[i]);
            //}
            console.log('FINAL' + JSON.stringify(resp));

            JsonData = resp;


            drawGraph(currentLevel, JsonData);



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
    var currentLevel = currentLevel;
    prevParentPositionY = 0;
    var currlevel = 1;
    prevParentPositionX = 250;
    var len = JsonData.length;
    paper.setDimensions(parseInt(len * 400, 10), parseInt(currentHeight * 400, 10));

    for (var i in JsonData) {
        if (JsonData[i].Level != currlevel)
            prevParentPositionX = 250;
        //set first positioning
        if (JsonData[i].Level == 1 && JsonData[i].shapeType != "Link") {
            //prevParentPositionY = 250;
            prevParentPositionX = prevParentPositionX + 150;
            currlevel = JsonData[i].Level;
        }
        if (JsonData[i].Level == 2 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType != "Cylinder") {
            prevParentPositionY = 350;
            prevParentPositionX = prevParentPositionX + 180;
            currlevel = JsonData[i].Level;
        }
        if (JsonData[i].Level == 2 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Cylinder") {
            prevParentPositionY = 350;
            prevParentPositionX = prevParentPositionX + 250;
            currlevel = JsonData[i].Level;
        }
        if (JsonData[i].Level == 3 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType != "Cylinder") {
            prevParentPositionY = 650;
            prevParentPositionX = prevParentPositionX + 180;
            currlevel = JsonData[i].Level;
        }
        if (JsonData[i].Level == 3 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Cylinder") {
            prevParentPositionY = 650;
            prevParentPositionX = prevParentPositionX + 250;
            currlevel = JsonData[i].Level;

        }
        if (JsonData[i].Level == 4 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType != "Cylinder") {
            prevParentPositionY = 950;
            prevParentPositionX = prevParentPositionX + 180;
            currlevel = JsonData[i].Level;
        }

        if (JsonData[i].Level == 4 && JsonData[i].shapeType != "Link" && JsonData[i].shapeType == "Cylinder") {
            prevParentPositionY = 950;
            prevParentPositionX = prevParentPositionX + 250;
            currlevel = JsonData[i].Level;
        }
        if (JsonData[i].Level == 5 && JsonData[i].shapeType != "Link") {
            prevParentPositionY = 1250;
            prevParentPositionX = prevParentPositionX + 150;
            currlevel = JsonData[i].Level;

        }
        if (JsonData[i].shapeType == "Rectangle" && JsonData[i].shapeType != "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Rectangle();
            window[JsonData[i].shapeControlName] = controlName;
            controlName.position(prevParentPositionX + 150, prevParentPositionY);
            controlName.resize(170, 60);
            controlName.attr({
                body: {
                    fill: '#f7a07b',
                    stroke: 'black',
                    strokeWidth: 2
                },
                label: {
                    text: JsonData[i].shapeLabel,
                    fill: 'black'
                }
            });
            controlName.addTo(graph);
        }
        if (JsonData[i].shapeType == "Cylinder" && JsonData[i].shapeType != "Link") {

            var controlName = JsonData[i].shapeControlName;
            controlName = new joint.shapes.standard.Cylinder();
            window[JsonData[i].shapeControlName] = controlName;
            controlName.resize(60, 60);
            controlName.position(prevParentPositionX + 150, prevParentPositionY);
            controlName.attr('root/title', 'joint.shapes.standard.Cylinder');
            controlName.attr('body/fill', 'lightgray');
            controlName.attr('top/fill', 'gray');
            controlName.attr('label/text', JsonData[i].shapeLabel);
            controlName.topRy('10%');
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
                //args: { step: 500 }

            });
            controlName.addTo(graph);
        }
    }
    var isApp = checkIsApplication(clickedElementName, JsonData);
    console.log(isApp);
    drawLeftChild(currentLevel, isApp);
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

$("#applicationList").change(function () {
    count = 0;
    JsonData = [];
    graph.clear();
    bindData();
    $("#btnLoad").show();

});




