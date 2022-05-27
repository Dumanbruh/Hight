const detailApi = "https://hightapp.herokuapp.com/estabilishments/ " + new URLSearchParams(location.search).get("id");
const getFavApi = "https://hightapp.herokuapp.com/auth/favourites"
var eventsUrl = `https://hightapp.herokuapp.com/estabilishments/events`

function search() {
  var inputText = document.getElementById("searchText");
  if (event.key === "Enter") {
    event.preventDefault();

    window.location.href = `http://localhost:5501/categories.html?s=${inputText.value}&type=Hotel`

    if(new URLSearchParams(location.search).get("auth") != null){
      window.location.href = `http://localhost:5501/categories.html?s=${inputText.value}&type=Hotel&auth=${new URLSearchParams(location.search).get("auth")}`
    }
  }
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
async function getDetails() {
  const response = await fetch(detailApi);
  const details = await response.json();


  console.log(details)//changed line to assign the textcontent to new variable

  document.getElementById("navname").innerHTML = details.name;
  document.getElementById("navtype").innerHTML = details.typeName;

  document.getElementById("estabilishmentName").innerHTML = details.name

  document.getElementById("estabilishmentDescription").innerHTML = details.description

  document.getElementById("reviewNumTop").innerHTML = details.reviewNum  
  document.getElementById("reviewNumBottom").innerHTML = details.reviewNum  + ' reviews'
  
  document.getElementById("website").innerHTML = '<a href="' + details.website + '">website</a>';

  document.getElementById("location").innerHTML = '<iframe src="' + details.location + '" height = "400" width = "420" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>';
  for(let i = 0; i < details.estabilishmentImages.length; i++){  
    document.getElementById("imagesPreview").innerHTML += `<div class="swiper-slide"><div class="slider__image"><img src="${details.estabilishmentImages[i].title}" alt=""/></div></div>`
    document.getElementById("images").innerHTML += `<div class="swiper-slide"><div class="slider__image"><img src="${details.estabilishmentImages[i].title}" alt=""/></div></div>`
  }  

  if(details.overallRating === null && details.locationRating === null && details.serviceRating === null && details.price_qualityRating === null){
    document.getElementById("noResult").innerHTML = "<div class='averageRating'><span>No ratings</span></div>";
  }
  else{
    document.getElementById("overallRating").innerHTML = details.overallRating;
    document.getElementById("locationRating").innerHTML = details.locationRating;
    document.getElementById("serviceRating").innerHTML = details.serviceRating;
    document.getElementById("price_qualityRating").innerHTML = details.price_qualityRating;
  }
  blockButton()
}

async function blockButton(){
  const getFav = await fetch(getFavApi,{
    headers : {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`
    }
  });
  var fav = await getFav.json();
    for(let i = 0; i < fav.length; i++){
      if(new URLSearchParams(location.search).get("id") == fav[i].estabilishmentId && fav != null){
      document.getElementById("addFav").innerHTML = '<span>Already saved</span>'
      document.getElementById("addFav").disabled = true
    }
  }
}

async function addFavourites(){
  
  if(new URLSearchParams(location.search).get("auth") == "null"){
    window.location.replace(`http://localhost:5501/signin.html`);
  }

  document.getElementById("addFav").innerHTML = '<span>Already saved</span>'
  document.getElementById("addFav").disabled = true
  
  const favApi = "https://hightapp.herokuapp.com/auth/favourites/" + new URLSearchParams(location.search).get("id")
  const addFav = await fetch(favApi,{
    method: "POST",
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'Authorization': `bearer ${new URLSearchParams(location.search).get("auth")}`}
      });

}



getDetails()