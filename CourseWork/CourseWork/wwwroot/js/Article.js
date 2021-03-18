function showImg(event) {
    context = event.target.files[0];
    divImg = document.getElementById("divForImg");
    img = document.createElement("img")
    img.src = window.URL.createObjectURL(context);
    divImg.appendChild(img);
}