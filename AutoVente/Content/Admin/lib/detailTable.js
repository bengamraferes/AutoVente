let detailBtns = document.querySelectorAll(".detail-btn");
detailBtns.forEach((e) => {
    let i = e.querySelector("i");
    e.addEventListener("click", ec => {
        let idEc = e.getAttribute('id');
        let id = idEc.slice(11);
        let tr = document.querySelector("#detail-tr-" + id)

        tr.classList.add("active");
        i.classList.toggle("fa-plus-circle")
        i.classList.toggle("fa-minus-circle")
        tr.classList.toggle("hidden")

    })
    if (tr.classList.contains("active" + id) && tr.classList.contains("hidden")) {
        tr.classList.remove("hidden")
        i.classList.toggle("fa-minus-circle")
    }
   
})
window.onload = function () {
    let actives = document.querySelectorAll(".active");
    actives.forEach((e) => {

    })
}