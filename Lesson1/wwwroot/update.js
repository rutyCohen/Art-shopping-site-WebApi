
function update() {
    let user = {
        UserId: JSON.parse(sessionStorage.getItem('user')).userId,
        Email: document.getElementById("email3").value,
        Password: document.getElementById("password3").value,
        FirstName: document.getElementById("firstName3").value,
        LastName: document.getElementById("lastName3").value,
      

    }
    fetch("api/Server/"+user.UserId ,{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }).then(response => 
    {
        if (response.ok)
            alert('your new details saved successfully');
        })
};

function user() {
    let user = JSON.parse(sessionStorage.getItem('user'));

     document.getElementById("email3").value = user.email;
     document.getElementById("password3").value = user.password;
     document.getElementById("firstName3").value = user.firstName;
     document.getElementById("lastName3").value = user.lastName;

    


   

};