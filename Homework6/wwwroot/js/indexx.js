$(document).ready(function () {
    var login = $('#loginform');
    var register = $('#registerform');
    var loc = window.location + '';
    var ee = loc.split('#');

    if (ee[1] = 'registerform' && ee[1] != undefined) {
        $('#loginbox').css({ 'height': '360px' });
        login.css({ 'z-index': '100', 'opacity': '0' });
        register.css({ 'z-index': '200', 'opacity': '1', 'display': 'block' });
    }

    $('.to-register').click(function () {
        switch_container(register, login, 350);
    });
    $('.to-login').click(function () {
        switch_container(login, register, 270);
    });

});

$('#sub_login').click(function () {
    var userno = $("#userno").val();
    var password = $("#password").val();

    if (userno.value === "") {
        alert("�˺Ų���Ϊ��!!");//�˺Ų���Ϊ��
        return false;
    }
    if (password.value === "") {
        alert("���벻��Ϊ��!");
        return false;
    }
    var pattern = /^[\w_-]{8,24}$/;
    if (!pattern.test(password.value)) {
        alert("�����ʽ����ȷ!");
        return false;
    }
    //console.time("���Լ����ٶ�: ");
    //password.value = encrypt(password);
    //console.timeEnd("���Լ����ٶ�: ");
    //console.log(password.value)
});

$('#sub_register').click(function () {
    var userno = $("#ruserno").val();

    var password = $("#rpassword").val();
    var relpassword = $("#relpassword").val();

    if (userno === "") {
        alert("�˺Ų���Ϊ��!!");//�˺Ų���Ϊ��
        return false;
    }
    if (password === "") {
        alert("���벻��Ϊ��!!");
        return false;
    }
    var pattern = /^[\w_-]{8,24}$/;
    if (!pattern.test(password)) {
        alert("�����ʽ����ȷ!");
        return false;
    }
    if (relpassword === "") {
        alert("ȷ�����벻��Ϊ��!!");
        return false;
    }
    if (relpassword !== password) {
        alert("�������벻һ��!");
        return false;
    }
    //console.time("���Լ����ٶ�: ");
    //$("#rpassword").val(encrypt(password));
    //console.timeEnd("���Լ����ٶ�: ");
});

function encrypt(str) {
    var encrypt_str = str.value;
    for (var i = 0; i < 4096; i++) {
        var shaObj = new jsSHA("SHA-512", "TEXT");
        shaObj.update(encrypt_str);
        encrypt_str = shaObj.getHash("HEX");
        // console.log(encrypt_str)
    }
    return hex_md5(encrypt_str);
}

function switch_container(to_show, to_hide, cwidth) {
    to_hide.css('z-index', '100').fadeTo(300, 0.01, function () {
        $('#loginbox').animate({ 'height': cwidth + 'px' }, 300, function () {
            to_show.fadeTo(300, 1).css('z-index', '200');
        });
    });
}

// var param = {
//     N: 8,   // ʱ�ճɱ�
//     r: 8,       // ���С
//     P: 4        // ����ά��
// };
// var opt = {
//     maxPassLen: 32, // ��������С����
//     maxSaltLen: 32,
//     maxDkLen: 32,
//     maxThread: 2    // ���ʹ�õ��߳���
// };
// scrypt.onload = function() {
//     console.log('scrypt loaded');
//     try {
//         scrypt.config(param, opt);
//     } catch (err) {
//         alert('config err: ' + err.message);
//     }
// };
// function init(){
//     scrypt.setResPath('./asset');
//     var mods = scrypt.getAvailableMod();
//     if (mods.length === 0) {
//         alert('���������֧�� asm.js ���� Flash Player 18+');
//         return;
//     }
//     scrypt.load();
//
// }

// function encrypt(str) {
//     var encrypt_str = scrypt.strToBin(str.value);
//     console.log('encrypt_str: ' + encrypt_str);
//
//     try {
//         scrypt.hash(encrypt_str, "", 32);
//     } catch (err) {
//         alert('hash err: ' + err.message);
//     }
// }
// scrypt.oncomplete = function(dk) {
//     console.log('dk: ' + scrypt.binToHex(dk));
//     var pwd = document.getElementById("password");
//     pwd.value =  scrypt.binToHex(dk)
// };
// function sleep(numberMillis) {
//     //��¼��ǰʱ��
//     var now = new Date();
//     //����δ����ĳ��ʱ��
//     var exitTime = now.getTime() + numberMillis;
//     while (true) {
//         //��ȡ��ǰʱ��
//         now = new Date();
//         //����Ƿ������úõ�δ��ʱ��
//         if (now.getTime() > exitTime)
//             return;
//     }
// }
// $(init)

