let detailBtns = document.querySelectorAll(".detail-btn");
detailBtns.forEach((e) => {
    e.addEventListener("click", ec => {
        let idEc = e.getAttribute('id');
        let id = idEc.slice(11);
        let tr = document.querySelector("#detail-tr-" + id)
        let i = e.querySelector("i");
        i.classList.toggle("fa-plus-circle")
        i.classList.toggle("fa-minus-circle")
        tr.classList.toggle("hidden")
    })
})