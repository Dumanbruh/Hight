const checkAuth = 
       "https://hightapp.herokuapp.com/Auth"
const getFavApi = 
        "https://hightapp.herokuapp.com/auth/favourites"
const delFavApi =
        "https://hightapp.herokuapp.com/auth/favourites"


       
fetch(checkAuth, {
        method: 'GET',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
        }
    })
.then((response) => response.json())
.then((repos) => {
    const user = repos.map((repo) => repo);
    showUserDetails(user);
})
.catch((err) => console.log(err));

fetch(getFavApi,{
    method: 'GET',
    headers : {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
    }
})
.then((response) => response.json())
.then((repos) => {
    const favs = repos.map((repo) => repo);
    showUserFavs(favs);
})
.catch((err) => console.log(err));




async function showUserDetails(user){  
    document.getElementById("fname").value=user[0].firstname
    document.getElementById("lname").value=user[0].lastname 
    document.getElementById("email").value=user[0].email 

    document.getElementById("privateCab").innerHTML = `<a class="dropdown-item" href="http://localhost:5501/cabinet.html?auth=${new URLSearchParams(location.search).get("auth")}">Profile</a>`
    document.getElementById("mainPage").href = `http://localhost:5501/index.html?auth=${new URLSearchParams(location.search).get("auth")}`
}


async function showUserFavs(data){

    let estabilishmentCard = document.getElementById('estabilishmentsList');

    for (let r of data) {
        if (r.overallRating == null) {
            r.overallRating = 0;
        }

    estabilishmentCard.innerHTML += `                    
        
        <div class = "card">        
            <button class="close" onClick = "deleteFav(${r.estabilishmentId})">x</button>

            <a id = "productUrl" href = "http://localhost:5501/product.html?id=${r.estabilishmentId}&auth=${new URLSearchParams(location.search).get("auth")}">                    
                                    
                <div class="product-item">  
                    <div class="productCard">
                        <div class="image">
                            <picture class><img src="${r.imageTitle}" style="width: 391px; height: 301px; border-radius:16px " alt=""></picture>
                        </div>            

                        <div class="info">
                            <div class="text">
                                <h2>${r.name}</h2>
                                <div class="rating" id="ratings">
                                    <img src="img/icons/Star.svg" alt="">
                                    <img src="img/icons/Star.svg" alt="">
                                    <img src="img/icons/Star.svg" alt="">
                                    <img src="img/icons/starop.svg" alt="">
                                    <img src="img/icons/starempty.svg" alt="">
                                    <span>Review number: ${r.reviewNum}</span>
                                    <span>Rating: ${r.overallRating}</span>
                                </div>
                            </div>
                            <div class="features">
                                <ul>
                                    <li>
                                        <a href="${r.website}">${r.website}</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>               
                </div> 
            </a>
        </div`;
    }
}

async function updateUserDetails(){
    var fname = document.getElementById("fname").value
    var lname = document.getElementById("lname").value
    var email = document.getElementById("email").value

    const updateFavApi =
        `https://hightapp.herokuapp.com/auth`

    fetch(updateFavApi,{
        method: 'PUT',
        headers : {
            'Content-Type': 'application/json',
            'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
        },
        body: `{
            "firstname" : "${fname}",
            "lastname" : "${lname}",
            "email": "${email}"
        }`,
    })
    .then((response) => response.json())
    .then((repos) => {
        alert("Updated successfully!")
    })
    .catch((err) => alert("Updated successfully!"));
}

async function deleteFav(id){
    const delFavApi =
        `https://hightapp.herokuapp.com/auth/favourites/${id}`

    fetch(delFavApi,{
        method: 'DELETE',
        headers : {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
        }
    })
    .then((response) => response.json())
    .then((repos) => {
        fetchAgain();
    })
    .catch((err) => fetchAgain());

}

function fetchAgain(){
    fetch(getFavApi,{
        method: 'GET',
        headers : {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
        }
    })
    .then((response) => response.json())
    .then((repos) => {
        const favs = repos.map((repo) => repo);
        showUserFavs(favs);
    })
    .catch((err) => console.log(err));

    window.location.reload();
}