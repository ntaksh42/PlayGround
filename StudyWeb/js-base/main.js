'use strict'

const btnAdd = document.getElementById('btnAdd');
btnAdd.addEventListener('click', () => {
    const li = document.createElement('li');
    let text = document.getElementById('textInput');
    if(text.value === '') return ;
    const textNode = document.createTextNode(text.value);
    li.appendChild(textNode);
    const list = document.getElementById('list');
    list.appendChild(li);
}, false);

const selection = document.getElementById('selection');
selection.addEventListener('click', () => {

    while(selection.lastChild){
        selection.removeChild(selection.lastChild);
    }
    let newCnt = document.getElementsByTagName('li').length;
    for (let index = 0; index < newCnt; index++) {
        const newList = document.createElement('option');
        let newOp = document.createTextNode(index);
        newList.appendChild(newOp);
        selection.appendChild(newList);
    }
});


const btn = document.getElementById("btn");
btn.addEventListener('click', () => {
    window.alert("ぼたんおしたよ");
});


window.

// 置換を押したらItemが置き換わる。置き換え対象はドロップダウンで指定。
