let passwordR = document.getElementById("Password");
let email = document.getElementById("Email");
let username = document.getElementById("UserName");

let toggleBtnR = document.getElementById("lock");
let registerForm = document.querySelector("#registerForm");


function ToggleBtnR(){
    if(passwordR.type === "password"){
        passwordR.type = "text"
        toggleBtnR.innerHTML = `<i class='bx bxs-lock-open-alt'></i>`
    }else{
        passwordR.type = "password"
        toggleBtnR.innerHTML = `<i class='bx bxs-lock-alt'></i>`
    }
}

function Register(username, email, password){
    const body = {
        "username": username.value,
        "email":  email.value,
        "password": password.value
    }
    fetch('https://localhost:7187/Users/userRegister',{
        method : 'POST',
        body: JSON.stringify(body),
        headers: {
            'content-type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data =>
            {
                console.log(data)
                if(data.isSuccess){
                    alert('User registered successfully');
                    window.location.href = '/html/Main.html';
                }
                else{
                    alert('Can not register user');
                }
        })
        .catch(error => console.error('Error:', error));
}


registerForm.addEventListener('submit', function(e){
    e.preventDefault();
    Register(username,email,passwordR)
})
