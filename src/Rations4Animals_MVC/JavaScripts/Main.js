function getLists() {
    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            var cbSelectFeeds = document.getElementById("cbSelectFeeds");
            var Lists = JSON.parse(xhr.responseText);
            for (i = 0; i < Lists.feedstuffList.length; i++) {
                var option = document.createElement("option");
                option.text = Lists.feedstuffList[i][1];
                option.value = Lists.feedstuffList[i][0];
                cbSelectFeeds.add(option);
            }

            var lbFormula = document.getElementById("lbFormula");
            for (i = 0; i < Lists.feedFormulaList.length; i++) {
                var option = document.createElement("option");
                option.text = Lists.feedFormulaList[i][1];
                option.value = Lists.feedFormulaList[i][0];
                lbFormula.add(option);
            }
        }

    }

    xhr.open('POST', '/RationCalculator/FeedStuffAndFeedFormulas', true);
    xhr.send();
}

function addItemToSelectedList() {

    var selectFeedStuff = document.getElementById('cbSelectFeeds');

    var selectedFeedStuffIndex = selectFeedStuff.options[selectFeedStuff.selectedIndex].value;
    var selectedFeedStuffText = selectFeedStuff.options[selectFeedStuff.selectedIndex].text;
    var costperton = document.getElementById('txtCost').value;
    var limitFrom = document.getElementById('txtLimitFrom').value;
    var limitTo = document.getElementById('txtLimitTo').value;

    if (!document.getElementById('rbLimited').checked) {
        limitFrom = 0;
        limitTo = 100;
    }

    var lbFeeds = document.getElementById("lbFeeds");
    var option = document.createElement("option");
    option.text = selectedFeedStuffText + ' @ R ' + costperton + ' per ton';
    option.value = selectedFeedStuffIndex + ';' + costperton + ';' + limitFrom + ';' + limitTo;
    lbFeeds.add(option, lbFeeds[0]);


    document.getElementById('rbUnlimited').checked = true;
    document.getElementById('limitrow').style.display = 'none';

    document.getElementById('txtCost').value = '';
    document.getElementById('txtLimitFrom').value = '0';
    document.getElementById('txtLimitTo').value = '100';

}

function deleteItemToSelectedList() {


    var lbFeeds = document.getElementById("lbFeeds");

    if (lbFeeds.selectedIndex == -1) {
        alert("No item selected to delete");
    } else {
        lbFeeds.remove(lbFeeds.selectedIndex);
    }

}

function clearAllItems() {
    document.getElementById("lbFeeds").innerHTML = "";
}

function getOptimalPrice() {

    var texts = [];
    var values = [];
    var sel = document.getElementById('lbFeeds');
    for (var i = 0, n = sel.options.length; i < n; i++) {
        if (sel.options[i].text) texts.push(sel.options[i].text);
        if (sel.options[i].value) values.push(sel.options[i].value);
    }


    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {

            var data = JSON.parse(xhr.responseText);
            if (data.error) {
                document.getElementById('lbOutput').className = 'alert-danger';
                document.getElementById('lbOutput').innerHTML = 'No feasible solution for this ration was found with the raw materials selected';
            } else {
                document.getElementById('lbOutput').className = 'alert-success';
                document.getElementById('lbOutput').innerHTML = 'Your ration has been successfully formulated resulting in a least cost of R' + data.price + ' per ton of feed.';
                var a = document.getElementById('link');
                a.href = "Result?GUID=" + data.calculationGUID;
            }
        }

    }

    var data = new FormData();
    data.append('feedstuff', JSON.stringify(values));
    data.append('feedformula', document.getElementById('lbFormula').value);


    xhr.open('POST', '/RationCalculator/GetPrice', true);
    xhr.send(data);
}


function tabClick(index) {

    if (index == 0) {
        document.getElementById('homepage').style.display = 'block';
        document.getElementById('rationcalculatorpage').style.display = 'none';
        document.getElementById('homepage_link').style.background = '#66FF33';
    } else {
        document.getElementById('homepage_link').style.background = 'transparent';
    }

    if (index == 1) {
        document.getElementById('homepage').style.display = 'none';
        document.getElementById('rationcalculatorpage').style.display = 'block';
        document.getElementById('rationcalculatorpage_link').style.background = '#66FF33';
    } else {
        document.getElementById('rationcalculatorpage_link').style.background = 'transparent';
    }

}

function rblimitsclicked() {

    if (!document.getElementById('rbLimited').checked) {
        document.getElementById('limitrow').style.display = 'none';
    } else {
        document.getElementById('limitrow').style.display = 'block';
    }
}

function uploadToDatabase() {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            alert(xhr.responseText);
        }
    }

    var f = document.getElementById('fileinput').files[0];

    if (f) {
        var r = new FileReader();
        r.onload = function (e) {
            var contents = e.target.result;
            var data = new FormData();
            data.append('csvFile', contents);
            xhr.open('POST', '/Database/InjectData', true);
            xhr.send(data);
        }
        r.readAsText(f);
    } else {
        alert("Failed to load file");
    }
}

