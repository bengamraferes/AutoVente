let detailBtns = document.querySelectorAll(".detail-btn");
let actives = document.querySelectorAll(".active");
console.log(actives)
actives.forEach((e) => {
    e.classList.remove("hidden")

})
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
   
})

          
  