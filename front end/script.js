var form = document.getElementById("user-form");

var validation = (regex, input, errorElement, errorMessage, validMessage) => {
    errorElement.textContent = "";
    if (!regex.test(input.value)) {
        errorElement.textContent = errorMessage;
        errorElement.style.color = "red";
        errorElement.classList.add("active");
        return false;
    }
    errorElement.textContent = validMessage;
    errorElement.classList.add("active");
    errorElement.style.color = "green";
    return true;
}

form.addEventListener("submit", (e) => {
    e.preventDefault();

    var nameInput = document.querySelector("#name");
    var nameError = document.querySelector("#name-error");
    var emailInput = document.querySelector("#email");
    var emailError = document.querySelector("#email-error");
    var passwordInput = document.querySelector("#password");
    var passwordError = document.querySelector("#password-error");

    const regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const regexSenha = /^(?=.*\d).{6,}$/;
    const regexName = /^(?!_)[a-zA-Z0-9_]{3,16}(?<!_)$/;

    var emailValid = validation(regexEmail, emailInput, emailError, "Email inválido*", "Email válido!");
    var passwordValid = validation(regexSenha, passwordInput, passwordError, "Senha inválida*", "Senha válida!");
    var nameValid = validation(regexName, nameInput, nameError, "Nome inválido*", "Nome válido!");

    if (emailValid && passwordValid && nameValid) {
        setTimeout(() => {
            alert("Dados prontos para serem enviados para o servidor!");
        }, 1000);
    }
});
