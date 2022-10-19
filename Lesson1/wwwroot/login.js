function login() {
    let email = document.getElementById("email1").value;
    let password = document.getElementById("password1").value;
    fetch("api/Server/" + email + "/" + password) 
        .then(res => {
            if (res.ok && res.status == 200)
                return res.json();
            if (response.status == 204)
                alert("שם המשתמש חייב לכלול את הסימן @");

            else
                alert("אינך רשום במערכת, אנא הרשם")})
        .then(data => {
            
            alert("welcome back " + data.firstName + " " + data.lastName);
            window.location.href = "ExsistingUser.html";
            sessionStorage.setItem("user", JSON.stringify(data));
        })
        //.catch("אינך רשום במערכת, אנא הרשם")
};

function sign() {
    let user = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,

    }

    fetch("api/Server", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }).then(response => response.json())
 
        .then(data => {
            user.userId = data;
            console.log('Success:', data);
            alert('you sign successfully', data);
            window.location.href = "products.html";
            sessionStorage.setItem("user", JSON.stringify(data));

        })

};

