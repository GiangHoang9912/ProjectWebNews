const canvas = document.getElementById("canvas1");
const ctx = canvas.getContext('2d');
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;

let particlcesArray;

let mouse = {
    x: null,
    y: null,
    radius: (canvas.height / 150) * (canvas.width / 150)
}
window.addEventListener('mousemove',
    function (evnet) {
        mouse.x = this.event.x;
        mouse.y = this.event.y;
    }
);

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

class Particle {
    constructor(x, y, directionX, directionY, size, color) {
        this.x = x;
        this.y = y;
        this.directionX = directionX;
        this.directionY = directionY
        this.size = size;
        this.color = color;
    }
    draw() {
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2, false);
        ctx.fillStyle = "#fff";
        ctx.fill();
    }
    update() {
        // nếu particle out width size x random y=0
        if (this.x > canvas.width || this.x < 0 || this.y > canvas.height) {
            this.y = 0;
            this.x = Math.random() * 1500;
        }
        //drop particle down
        if (this.y < 0) {
            this.directionY = + this.directionY;
        }

        let dx = mouse.x - this.x;
        let dy = mouse.y - this.y;

        //particle move out mourse.x, mourse.y
        let distance = Math.sqrt(dx * dx + dy * dy);

        if (distance < mouse.radius + this.size) {
            if (mouse.x < this.x && this.x < canvas.width - this.size * 10) {
                this.x += 10;
            }
            if (mouse.x > this.x && this.x > this.size * 10) {
                this.x -= 10;
            }
            if (mouse.y < this.y && this.y < canvas.height - this.size * 10) {
                this.x += 10;
            }
            if (mouse.y > this.y && this.x > this.size * 10) {
                this.y -= 10;
            }
        }
        this.x -= 0.1;
        this.y += this.directionY;

        this.draw();
    }
}
function init() {
    particlcesArray = [];
    let numberOfParticlces = 1000;
    for (let i = 0; i < numberOfParticlces; i++) {
        let size = 3;
        let x = (Math.random() * 1500 + ((innerWidth - size * 2) - (size * 2)) + size * 2);
        let y = (Math.random() + ((innerHeight - size * 2) - (size * 2)) + size * 2);
        let directionX = (Math.random() * 3) - 2;
        let directionY = (Math.random() * 3) - 2;
        let color = '#8C5523';
        particlcesArray.push(new Particle(x, y, directionX, directionY, size, color));

    }
}

function animate() {
    requestAnimationFrame(animate)
    ctx.clearRect(0, 0, innerWidth, innerHeight);

    for (let i = 0; i < particlcesArray.length; i++) {
        particlcesArray[i].update();
    }
    //connect();
}

function connect() {
    let opacityValue = 1;
    for (let a = 0; a < particlcesArray.length; a++) {
        for (let b = a; b < particlcesArray.length; b++) {
            let distance = ((particlcesArray[a].x - particlcesArray[b].x)
                * (particlcesArray[a].x - particlcesArray[b].x))
                + ((particlcesArray[a].y - particlcesArray[b].y)
                    * (particlcesArray[a].y - particlcesArray[b].y));
            if (distance < (canvas.width / 10) * (canvas.height / 10)) {
                opacityValue = 1 - (distance / 20000);
                ctx.strokeStyle = 'rbga(140,85,31,' + opacityValue + ')';
                ctx.lineWidth = 1;
                ctx.beginPath();
                ctx.moveTo(particlcesArray[a].x, particlcesArray[a].y);
                ctx.lineTo(particlcesArray[b].x, particlcesArray[b].y);
                ctx.stroke();
            }
        }
    }
}

window.addEventListener('resize', function () {
    canvas.width = this.innerWidth;
    canvas.height = this.innerHeight;
    mouse.radius = ((canvas.height / 80) * (canvas.height / 80))
    init();
})
window.addEventListener('mouseout', function () {
    mouse.x = undefined;
    mouse.y = undefined;
})

init();
animate();

function myFunction() {
    var x = document.getElementById("loginform");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function ChangePass() {
    var x = document.getElementById("ChangePass");
    var y = document.getElementById("ContentPlaceHolder1_btnSave");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
    if (x.style.display === "none") {
        y.style.display = "block";
    } else {
        y.style.display = "none";
    }
}

function IndexChangeColor() {
    var index = document.getElementById("ContentPlaceHolder1_Label1").textContent.toString() - 1;
    var id = "ContentPlaceHolder1_btnPage_btnLink_".concat(index);
    document.getElementById(id).style.color = "#ff0000";


}
function requiredFunLogin() {
    var login = document.getElementById("loginform");

    if (login.style.display === "block") {
        document.getElementById("UserName").required = true;
        document.getElementById("Password").required = true;
    } else {
        document.getElementById("UserName").required = false;
        document.getElementById("Password").required = false;
    }
}

function checkFileExtension(elem) {
    var filePath = elem.value;

    if (filePath.indexOf('.') == -1)
        return false;

    var validExtensions = new Array();
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

    validExtensions[0] = 'doc';
    validExtensions[1] = 'docx';

    for (var i = 0; i < validExtensions.length; i++) {
        if (ext == validExtensions[i])
            return true;
    }

    alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');


    return false;
}

function requiredUpdateUser() {
    document.getElementById("ContentPlaceHolder1_FullName").required = true;
    document.getElementById("ContentPlaceHolder1_DateOfBirth").required = true;
    document.getElementById("ContentPlaceHolder1_Email").required = true;
    document.getElementById("ContentPlaceHolder1_Phone").required = true;
}
function requiredChangePass() {
    var changPass = document.getElementById("ChangePass");
    if (changPass.style.display === "block") {
        requiredUpdateUser();
        document.getElementById("ContentPlaceHolder1_OldPass").required = true;
        document.getElementById("ContentPlaceHolder1_NewPass").required = true;
        document.getElementById("ContentPlaceHolder1_confirmPass").required = true;
    } else {
        document.getElementById("ContentPlaceHolder1_OldPass").required = false;
        document.getElementById("ContentPlaceHolder1_NewPass").required = false;
        document.getElementById("ContentPlaceHolder1_confirmPass").required = false;
    }
}

function requiredAddNews() {
    document.getElementById("ContentPlaceHolder1_TitleNews").required = true;
    document.getElementById("ContentPlaceHolder1_TextBox1").required = true;
    document.getElementById("ContentPlaceHolder1_filename").required = true;
}
function requiredCreateAccount() {
    document.getElementById("ContentPlaceHolder1_FullName").required = true;
    document.getElementById("ContentPlaceHolder1_DateOfBirth").required = true;
    document.getElementById("ContentPlaceHolder1_Email").required = true;
    document.getElementById("ContentPlaceHolder1_Phone").required = true;

    document.getElementById("ContentPlaceHolder1_Account").required = true;
    document.getElementById("ContentPlaceHolder1_Password").required = true;
    document.getElementById("ContentPlaceHolder1_Confirm").required = true;
}
