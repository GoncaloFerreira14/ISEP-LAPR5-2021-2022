const express = require('express');
const cors = require('cors');
const app = express();

var corsOptions = {
    origin: '*',
    optionsSuccessStatus: 200,
}

app.use(cors(corsOptions));
app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
})

const PORT = process.env.PORT || 8080;

app.use(express.static(__dirname + '/dist/SN-FE'));
app.get('/', (req, res) => {
    res.sendFile(__dirname + '/dist/SN-FE/index.html');
});


app.listen(PORT, () => {
    console.log('Server open on  ' + PORT);
});