var express =  require('express');
var fs = require('fs');
var multer = require('multer');
var bodyParser = require('body-parser');
var storage = multer.diskStorage({
    destination:function(req, file, cb){
        cb(null, 'mapdata/');
    },
    filename: function(req, file, cb){
        cb(null, file.originalname);
    }
});
var upload = multer({storage:storage});
var app = express();
app.set('view engine', 'pug');                                                                   
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended : true}));


//홈
app.get('/mapdata', function(req,res){
    res.writeHead(200, {'Content-Type':'text/html;charset=utf8'});
    res.write("<h1>패턴등록사이트</h1>");
    res.write("<h2>패턴 올리기</h2>");
    res.write("<form action=\"mapdata\" method=\"post\" enctype=\"multipart/form-data\"> <input type=\"file\" name=\"userfile\"> <input type=\"submit\"> </form>");
    res.write("<h2>패턴 목록</h2>");
    var mapdataName = [];
    var files = fs.readdirSync('mapdata');
    res.write("<form action=\"/del\" method=\"post\">");
    for(var i = 0; i < files.length; i++)
    {
        var file = files[i];
        var idx = file.lastIndexOf('.');
        var suffix = file.substring(0,idx);
        mapdataName.push(suffix);
        var href = "<input id='"+i+"' name='inputBox' value='"+mapdataName[i]+"' type='checkbox'><a href=\"/mapdata/view/"+mapdataName[i]+"\">"+mapdataName[i]+"</a><br>";
        res.write(href);
    }
    res.write("<br><input type=\"submit\" value='삭제'></input></form>");
    const article = fs.readFileSync("./member.txt");
    lineArray = article.toString().split('\n');
    res.write("<br><br>"+"<a id='lineArray'>"+lineArray+"</a><br>");
    // res.write("<br>"+"<input id='inputlineArray' type='text' name='member_name' value='"+lineArray+"' style='display:none;'>");

    res.write("<br><button onclick='modiClick()'>수정</button>");
    
    var inner = `<input id="inputval" value="${lineArray}" style="width:1000px;">`;

    res.write(`<script> var check = false; function modiClick(){if(check == true){var inputTage = document.getElementById("inputval"); location.href="/mapdata/membermodi/"+inputTage.value;}else{var aTage = document.getElementById("lineArray"); aTage.innerHTML = '${inner}'; check = true;}}</script>`);

    res.end();
});

app.get('/mapdata/view/:id',function(req,res){
    res.writeHead(200, {'Content-Type':'text/html;charset=utf8'});
    var filePath = "./mapdata/"+req.params.id+".json";
    const article = fs.readFileSync(filePath);
    var lineArray = article.toString().split('\n');
    var downloadHref = "/mapdata/download/"+req.params.id
    var homeHref = "/mapdata"

    res.write("<p>"+lineArray+"</p>");
    res.write("<br><button onclick=\"location.href='"+downloadHref+"'\">다운로드</button>");
    res.write("<br><button onclick=\"location.href='"+homeHref+"'\">홈으로</button>");
});

//이름 수정
app.get('/mapdata/membermodi/:id',function(req,res){
    var data = req.params.id;
    fs.writeFile('./member.txt', data, 'utf8', function(error){ console.log('write end') });
    res.writeHead(302,{'location':'http://13.125.231.26:3000/mapdata'});
    res.end();
});

//패턴다운로드
app.get('/mapdata/download/:id',function(req,res){
    var filePath = "./mapdata/"+req.params.id+".json";
    res.download(filePath);
});

//패턴삭제
app.post('/del', function(req,res){
    var namelist = req.body.inputBox;

    if(namelist instanceof Array){
        for(var i = 0;i<namelist.length;i++){
            var filePath = "./mapdata/"+namelist[i]+".json";
            fs.unlink(filePath, function (err) {
                if (err) throw err;
            });
        }
    }
    else {
        var filePath = "./mapdata/"+namelist+".json";
        fs.unlink(filePath, function (err) {
            if (err) throw err;
        }); 
    }
    res.writeHead(302,{'location':'http://13.125.231.26:3000/mapdata'});
    res.end();
});

//패턴업로드
app.post('/mapdata', upload.single('userfile'), function(req, res){
    res.writeHead(200, {'Content-Type':'text/html;charset=utf8'});
    res.write('<h1>업로드 성공!</h1>');
    res.write('<h2><a href=\"/mapdata\">홈으로</a></h2>');
    res.end();
    console.log(req.file);
});

//패턴데이터확인
app.get('/mapdata/:id',function(req, res){
    fs.readFile('./mapdata/'+ req.params.id +'.json',function(err, data){
        res.writeHead(200, {'Content-Type':'text/html;charset=utf8'});
        res.write(data);
        res.end();
    });
});

app.listen(3000, function()
{
    console.log('Conneted 3000 port!');
});