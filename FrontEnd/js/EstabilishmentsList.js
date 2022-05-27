var estabilishmentsUrl = `https://hightapp.herokuapp.com/estabilishments?type=${new URLSearchParams(location.search).get("type")}&page=${new URLSearchParams(location.search).get("page")}`;
var eventsUrl = `https://hightapp.herokuapp.com/estabilishments/events`

if(new URLSearchParams(location.search).get("s") != null){
   estabilishmentsUrl = `https://hightapp.herokuapp.com/estabilishments?s=${new URLSearchParams(location.search).get("s")}&type=${new URLSearchParams(location.search).get("type")}`
} 

if(new URLSearchParams(location.search).get("auth") != null){
  const checkAuth = 
     "https://hightapp.herokuapp.com/Auth"

  fetch(checkAuth, {
      method: 'GET',
      headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
      }
  })
      .then(
          function(response)
          {
          if(response.status===401)
          {
              throw new Error(response.status)
          }

          return response.json()
          })
      .then(repos => {
          const userauth = repos.map(repo => repo);
          checkUserAuth(userauth)
      })
  .catch(function(error)
  {
    hideUserIcon()
  })  
}
      
function hideUserIcon(){
  document.getElementById("userIcon").style.visibility = "hidden"
  document.getElementById("authIcon").style.visibility = "visible"                                   
}


function checkUserAuth(data){
  document.getElementById("userIcon").style.visibility = "visible"                                  
  document.getElementById("authIcon").style.visibility = "hidden"    
  document.getElementById("privateCab").innerHTML = `<a class="dropdown-item" href="http://localhost:5501/cabinet.html?auth=${new URLSearchParams(location.search).get("auth")}">Profile</a>`
  document.getElementById("estSubMenu").innerHTML = `										
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Hotel&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Hotel</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Cafe&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Cafe</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Fitness&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Fitness</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Pool&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Pool</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Mall&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Mall</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=nightClub&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Night club</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Track&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Track</span></a></li>
  <li><a class="nav-link" href="http://localhost:5501/categories.html?type=Sauna&page=1&auth=${new URLSearchParams(location.search).get("auth")}"><span>Sauna</span></a></li>`
  document.getElementById("mainPage").href = `http://localhost:5501/index.html?auth=${new URLSearchParams(location.search).get("auth")}`

}

function sort() {
  var select = document.getElementById("sorting");
  var value = select.options[select.selectedIndex].value;
  if (value == "ascRating") {
    estabilishmentsUrl =
      `https://hightapp.herokuapp.com/estabilishments?sortrate=desc&type=${new URLSearchParams(location.search).get("type")}&page=1`
  }
  if (value == "descRating") {
    estabilishmentsUrl =
      `https://hightapp.herokuapp.com/estabilishments?sortrate=asc&type=${new URLSearchParams(location.search).get("type")}&page=1`
  }
  if (value == "ascName") {
    estabilishmentsUrl =
      `https://hightapp.herokuapp.com/estabilishments?sortname=asc&type=${new URLSearchParams(location.search).get("type")}&page=1`;
  }
  if (value == "descName") {
    estabilishmentsUrl =
      `https://hightapp.herokuapp.com/estabilishments?sortname=desc&type=${new URLSearchParams(location.search).get("type")}&page=1`;
  }

  fetch(estabilishmentsUrl)
    .then((response) => response.json())
    .then((repos) => {
      const estabilishments = repos.map((repo) => repo);
      showEstabilishments(estabilishments);
    })
    .catch((err) => console.log(err));
}

function search() {
  var inputText = document.getElementById("searchText");

  if (event.key === "Enter") {
    event.preventDefault();
    estabilishmentsUrl = `https://hightapp.herokuapp.com/estabilishments?s=${inputText.value}`;

    fetch(estabilishmentsUrl)
    .then((response) => response.json())
    .then((repos) => {
      const estabilishments = repos.map((repo) => repo);
      showEstabilishments(estabilishments);
    })
    .catch((err) => console.log(err));
  }
}

fetch(estabilishmentsUrl)
  .then((response) => response.json())
  .then((repos) => {
    const estabilishments = repos.map((repo) => repo);
    showEstabilishments(estabilishments);
  })
  .catch((err) => console.log(err));

fetch(eventsUrl)
  .then((response) => response.json())
  .then((repos) => {
    const events = repos.map((repo) => repo);
    showEvents(events);
  })
  .catch((err) => console.log(err));

function showEvents(data){
  for(let r of data){
    document.getElementById("eventSubMenu").innerHTML += `<li><a class="nav-link" href="http://localhost:5501/event.html?id=${r.eventID}&auth=${new URLSearchParams(location.search).get("auth")}"><span>${r.title}</span> </a></li>`
  }
}

function showEstabilishments(data) {
  if(data.length <= 0){
    document.getElementById("noRes").style.visibility = "visible"
  }
  document.getElementById("typeName").innerHTML = data[0].typeName;
  document.getElementById("title").innerHTML = data[0].typeName + 's';
  document.getElementById("resNum").innerHTML = data.length + " results";

  let estabilishmentCard = '<div class="product-list" id="estabilishmentsList"></div>';

  for (let r of data) {
    if (r.overallRating == null) {
      r.overallRating = 0;
    }

    estabilishmentCard += `                   
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
        </a>`;
  }
  
  if(data.length <= 10){
    document.getElementById("pagination").innerHTML = `<li class="page-item"><a class="page-link" href="http://localhost:5501/categories.html?type=Hotel&page=1">1</a></li>`;
    document.getElementById("pagination").innerHTML += `<li class="page-item"><a class="page-link" href="http://localhost:5501/categories.html?type=Hotel&page=2">2</a></li>`;
  } 


  // Setting innerHTML as tab variable
  document.getElementById("estabilishmentsList").innerHTML = estabilishmentCard;

}


