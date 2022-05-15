const eventUrl = `https://hightapp.herokuapp.com/estabilishments/events/${new URLSearchParams(location.search).get("id")}`
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

function search() {
  var inputText = document.getElementById("searchText");
  if (event.key === "Enter") {
    event.preventDefault();
    window.location.href = `http://localhost:5501/categories.html?s=${inputText.value}`
  }
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
  const response = await fetch(eventUrl);
  const details = await response.json();


  console.log(details)//changed line to assign the textcontent to new variable

  document.getElementById("navname").innerHTML = details.title;
  document.getElementById("navtype").innerHTML = details.estabilishmentName;

  document.getElementById("estabilishmentName").innerHTML = details.title

  document.getElementById("estabilishmentDescription").innerHTML = details.description
  document.getElementById("eventTime").innerHTML = details.time
  if(details.price == 0){
    document.getElementById("price").innerHTML = "FREE" 
  }
  else{
    document.getElementById("price").innerHTML = details.price
  }

  document.getElementById("location").innerHTML = details.location

  document.getElementById("images").innerHTML = `<div class="swiper-slide"><div class="slider__image"><img src="${details.eventImage}" alt=""/></div></div>`

}

function showEvents(data){
    for(let r of data){
        document.getElementById("eventSubMenu").innerHTML += `<li><a class="nav-link" href="http://localhost:5501/event.html?id=${r.eventID}&auth=${new URLSearchParams(location.search).get("auth")}"><span>${r.title}</span> </a></li>`
    }
}

getDetails()