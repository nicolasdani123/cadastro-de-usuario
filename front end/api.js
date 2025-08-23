const formApi = document.querySelector("#user-form");

form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const data = {
        name: document.querySelector("#name").value,
        email: document.querySelector("#email").value,
        password: document.querySelector("#password").value
    };

    try {
        const response = await fetch("http://localhost:5225/api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });

        if (!response.ok) {
            throw new Error("Erro ao enviar dados");
        }

        const result = await response.json();
        alert("Usuário cadastrado com sucesso: " + result.name);

    } catch (error) {
        console.error("Erro:", error);
        alert("Falha ao cadastrar usuário");
    }
});
