'use strict'

const express = require('express');
const path = require("path");
const app = express();

app.use(express.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, "public")));

app.post("/api/v1/calc", function (req, res) {
    const ans = req.body.answer;
    const t = document.getElementById("inputText");
    t.innerText = ans * 10;
    //res.send(ans);
});

app.get('/', function (req, res) {
    res.send('cccc page')
})

app.get('/about', function (req, res) {
    res.send('about page')
})

app.listen(3000, () => {
    console.log("running")
});