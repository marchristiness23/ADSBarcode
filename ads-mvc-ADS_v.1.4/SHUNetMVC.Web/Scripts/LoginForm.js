let form = document.querySelector('form');

form.addEventListener('submit', (e) => {
    e.preventDefault();
    console.log(e);
    //window.location.href = window.location.href + '/';

    let el = document.getElementById("input-login-username");
    let url = (new URL('home/loginform' + '?userName=' + el.value, document.location)).href;
    console.log("newurl",url);
    fetch(url).then(function (response) {
        //console.log(location);
        location.reload();
        //window.location = window.location.href;
    });
});