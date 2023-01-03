'use strict'
const fs = require("fs");

const p = {
    name:"make",
    age : 30,
}

function read() {
    fs.readFile("./sample.txt", "utf-8", (err, data) => {
        console.log(data);
    })
}

function write(strWrite) {
    fs.writeFile("sample.txt", strWrite, () => {
    });
}

function readJson(){
    fs.readFile("sample.json", "utf-8", (err, data) => {
        const p = JSON.parse(data);
        console.log(p.name);
        console.log(p.age);
    })
}

function writeJson(){
    fs.writeFile("sample.json", JSON.stringify(p), () => {});
}

module.exports = {
    read: read,
    write: write,
    readJson: readJson,
    writeJson: writeJson,
}