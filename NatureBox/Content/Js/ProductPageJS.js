function myFunction(name,about) {
    console.log("Open!");
    document.querySelector(".about-title").innerHTML = name;
    var div = document.querySelector(".about-content");
    div.innerHTML = null;

    var inner='';

    for (var i = 0; i < about.length; i++) {
        if (about[i] != '.') {
            inner = inner + about[i];
        }
        else {
            inner = inner + ".";
            var p = document.createElement('p');
            p.innerHTML = inner;
            div.appendChild(p);
            inner = '';
        }
    }

    document.querySelector(".Effect").classList.add("open");
    document.querySelector(".Effect").classList.add("effect");

}


var modal = document.querySelector(".Effect");

modal.addEventListener("click", (e) => {
    if (e.target.classList.contains("about-page")) {

    }
    else {
        modal.classList.remove("open");
        document.querySelector(".Effect").classList.remove("effect");
    }
})
