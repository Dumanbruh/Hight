const login_api = 
      "https://hightapp.herokuapp.com/auth/login";

const reg_api =
      "https://hightapp.herokuapp.com/auth/register"

async function userAuth(){
    var email = document.getElementById('userEmail').value;
    var password = document.getElementById('userPass').value;
    const response = await fetch(login_api, {
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        body: `{
        "email": "${email}",
        "password": "${password}"
        }`,
    });

    var data = await response.json();
    console.log(data);

    if(data.message == 'Username or password is incorrect'){
        alert('Username or password is incorrect');
    }
    if(data != null){
        alert('Authorized successfully!');
    }
}

async function userReg(){
    var fname = document.getElementById('userFname').value;
    var lname = document.getElementById('userLname').value;
    var email = document.getElementById('userEmail').value;
    var password = document.getElementById('userPass').value;

    const response = await fetch(reg_api, {
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        body: `{
        "firstname" : "${fname}",
        "lastname" : "${lname}",
        "email": "${email}",
        "password": "${password}"
        }`,
    });

    var data = await response.json();
    console.log(data);

    if(data.message == 'Username or password is incorrect'){
        alert('Username or password is incorrect');
    }
    if(data.message == 'User registered!'){
        alert('User registered!');
    }
}


