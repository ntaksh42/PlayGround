// おまじない。
'use strict'

// let var が変数の宣言に使えるが、基本はletを使う。
// letにだけ、ブロックスコープがある。
// for (let i = 0; i < 10; i++) {
//     console.log(i);
// }

// 比較演算子
// == : 比較。型が違う場合もTRUE
// === : 厳密比較。型もチェックに入る。
// let num = 100;
// let str = '100';
// if (num === str) {
//     console.log('同じ');
// }

// 配列の宣言
// let hoge = [10];
// let colors = ['red', 'blue', 'green'];
// colors.forEach(element => {
//     console.log(element);
// });

// 連想配列
// hash dictionay mapなど
// const peopleMap = {name:'A', gender:'man'}


// function命令
function calcArea(height, width) {
    return height * width;
}

// 関数リテラル
const f1 = function(height, width){
    return height * width;
}

// Functionコンストラクタ
const f2 = new Function('height', 'width', 'return height * width')
console.log(f2(9,10));

// アロー関数
const f3 = (h, w) =>{
    return h * w;
}
console.log(f3(3, 4));

function calcPrice (num, unitPrice){
    return num * unitPrice;
}
console.log(calcPrice(13, 100));