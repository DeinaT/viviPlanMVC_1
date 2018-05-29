//window.onload = function () {
document.addEventListener("DOMContentLoaded", ready);
function ready() {
    var path = window.location.href; //полный путь
    var id = window.location.search; //номер пользователя
    
    var main = document.getElementById('main_broad');

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open('POST', path, true);
    xmlhttp.send(null);
    xmlhttp.onload = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                if (xmlhttp.responseText == 'Error') {
                    //такого пользователя в базе нет
                    alert('Error');
                }
                else {
                   // var jgy = xmlhttp.responseText.substring(17);
                    alert(xmlhttp.responseText);
                    var answer = xmlhttp.responseText.split(';'); //распарсили то, что пришло от сервака

                    var name = document.getElementById('name_out');
                    var nnn = document.createElement("h2");
                    nnn.innerHTML = answer[0];
                    name.appendChild(nnn); // вывели имя пользователя

                    for (var i = 1; i < answer.length-1;i++)
                    {
                        var answerBoard = answer[i].split(',');
                        var hyy = document.createElement("a");
                        hyy.href = 'board.html?id=' + answerBoard[0];
                        
                        var broad = document.createElement("div");
                        broad.className = 'board';
                        broad.innerHTML = '<h2>' + answerBoard[1] + '</h2>';
                        
                        hyy.appendChild(broad);
                        main.appendChild(hyy);
                    }

                    var broad = document.createElement("div");
                    var hyy = document.createElement("a");
                    broad.className = 'board new';
                    broad.innerHTML = '<h2><img src="img/plus.png">Создать новую доску...</h2>';
                    hyy.appendChild(broad);
                    main.appendChild(hyy);
                }
            }
        }
    }
}