let passwordL = document.getElementById("Password2");
let toggleBtnL = document.getElementById("lock2");

function ToggleBtnL(){
    if(passwordL.type === "password"){
        passwordL.type = "text"
        toggleBtnL.innerHTML = `<i class='bx bxs-lock-open-alt'></i>`
    }else{
        passwordL.type = "password"
        toggleBtnL.innerHTML = `<i class='bx bxs-lock-alt'></i>`
    }
}