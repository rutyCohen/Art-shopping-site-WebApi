function getOrder() {
    let c = JSON.parse(sessionStorage.getItem("counterCart"));
    document.getElementById("itemCount").innerHTML = c;
    document.getElementById("totalAmount").innerHTML = JSON.parse(sessionStorage.getItem("cost"));
    let cart = JSON.parse(sessionStorage.getItem("myCart"));

    for (let i = 0; i < cart.length; i++) {
        drowOrder(cart[i]);
    }
}

function drowOrder(product) {
    var url = "../Images/";
    let s = document.getElementById("temp-row");
    var clonS = s.content.cloneNode(true);
    clonS.querySelector(".image").src = url + product.prodImg ;
    clonS.querySelector(".itemName").innerHTML = product.prodName;
    clonS.querySelector(".price").innerHTML = product.prodPrice + ' ' + 'ש"ח ';
    clonS.querySelector(".expandoHeight").addEventListener("click", () => {
        deleteItem(product);
    });
    document.querySelector("tbody").appendChild(clonS);
}


function deleteItem(product) {

    let cart = JSON.parse(sessionStorage.getItem("myCart"));
    for (var i = 0; i < cart.length; i++) {
        if (product.prodId == cart[i].prodId)
        {
            var tempCart = cart.slice(0, i);
            var tempCart1 = cart.slice(i + 1, cart.length);
            cart = tempCart.concat(tempCart1);
            sessionStorage.setItem("myCart", JSON.stringify(cart));

            var cost = JSON.parse(sessionStorage.getItem("cost"));
            cost-= product.prodPrice;
            var count = JSON.parse(sessionStorage.getItem("counterCart"));
            count-= 1;

            sessionStorage.setItem("cost", JSON.stringify(cost));
            sessionStorage.setItem("counterCart", JSON.stringify(count));
            document.querySelector("tbody").replaceChildren();
            getOrder();
        }

    }
}

function placeOrder() {
    var items = [];
    var cart = JSON.parse(sessionStorage.getItem("myCart"));

    for (var i = 0; i < cart.length; i++) {
        var item = {
            //OrderItemId: 0,
            ProductId: JSON.parse(sessionStorage.getItem("myCart"))[i].prodId,
            //OrderId: 0,
            Quantity: 1
        }
        items.push(item);
    }
    let myCartDetails = {
       // OrderId: 0,
        OrderDate: new Date(),
        OrderSum: JSON.parse(sessionStorage.getItem("cost")),
        UserId: JSON.parse(sessionStorage.getItem("user")).userId,
        OrderItems: items
    };
    fetch("api/Orders", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(myCartDetails)
    }).then(response => {
        if (response.ok)
            return response.json();
        else
            response.json().then(error => { alert(JSON.stringify(error.errors)); });
    })
        .then(data => {
            alert(' הזמנתך מספר ' + data.orderId +'נקלטה בהצלחה, תודה ולהתראות');
            window.location.href = "products.html";
            let userIdForSession = JSON.parse(sessionStorage.getItem("user"));
            sessionStorage.clear();
            sessionStorage.setItem("user", JSON.stringify(userIdForSession));
    })

  
}






