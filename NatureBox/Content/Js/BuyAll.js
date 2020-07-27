function Open(data) { 
    var canvas = document.querySelector(".buy-all-canvas");
    canvas.classList.add("open-canvas");
    document.querySelector(".Effect-shop").classList.add("effect");
    document.querySelector(".buy-all-total").innerHTML ="Total:  "+data+" $";

}

function Close() {
    document.querySelector(".buy-all-canvas").classList.remove("open-canvas");
    document.querySelector(".Effect-shop").classList.remove("effect");
}




var canvas = document.querySelector(".Effect-shop");

canvas.addEventListener("click", (e) => {
    if (e.target.classList.contains("Effect-shop")) {
        Close();
    }
    
})

var checkbox = document.querySelectorAll(".input-pay");


document.querySelector(".buy-all-canvas").addEventListener('click', (e) => {
    if (e.target.classList.contains("input-pay")) {
        for (var i = 0; i < document.querySelectorAll(".input-pay").length; i++) {
            document.querySelectorAll(".input-pay")[i].checked = false;
        }
        e.target.checked=true;
    }
})
