var arr = ["https://picsum.photos/id/1/200/300", "https://picsum.photos/id/6/200/300", "https://picsum.photos/id/2/200/300", "https://picsum.photos/id/3/200/300", "https://picsum.photos/id/4/200/300", "https://picsum.photos/id/5/200/300"];
var mainImage = document.querySelector('.main-img-head');
var listImage = document.querySelector('.img-list');
var leftbtn = document.querySelector('.left');
var rightbtn = document.querySelector('.right');

if (arr[0] != null) {
    var main = `<img src="${arr[0]}" alt="">`;
    mainImage.innerHTML = main;

    for (let index = 0; index < arr.length; index++) {
        var result = `<img class="border border-secondary" src="${arr[index]}" alt="">`;
        listImage.innerHTML += result;

    }
    for (let index = 0; index < arr.length; index++) {
        listImage.children[index].addEventListener('click', function (e) {
            e.preventDefault();
            mainImage.children[0].src = listImage.children[index].src;
        })
    }

    
    leftbtn.addEventListener('click', function (e) {
        var deneme = arr.findIndex(e=>e.includes(mainImage.children[0].src))
        arrlength = arr.length;
        if(deneme < arr.length)
        {
            mainImage.children[0].src = arr[deneme-1]
        }
        if(deneme === 0)
        {
            mainImage.children[0].src = arr[arrlength-1]
        }
    })
    rightbtn.addEventListener('click', function (e) {
        var deneme = arr.findIndex(e=>e.includes(mainImage.children[0].src))
        if(deneme < arr.length)
        {
            mainImage.children[0].src = arr[deneme+1]
        }
        if(deneme === arr.length - 1)
        {
            mainImage.children[0].src = arr[0]
        }
    })
    // 
}