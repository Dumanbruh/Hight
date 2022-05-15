// api url
          
const topPlacesurl = 
      "https://hightapp.herokuapp.com/estabilishments?sortrate=desc"

const latestEventsurl = 
      "https://hightapp.herokuapp.com/estabilishments/events?sortrate=desc"

const checkAuth = 
       "https://hightapp.herokuapp.com/Auth"
  
fetch(topPlacesurl)
    .then(response => response.json())
    .then(repos => {
        const topPlaces = repos.map(repo => repo);
        showDestinations(topPlaces)
    })
.catch(err => console.log(err))
    
fetch(latestEventsurl)
    .then(response => response.json())
    .then(repos => {
        const events = repos.map(repo => repo);
        showEvents(events)
    })
.catch(err => console.log(err)) 

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
    document.getElementById("mainPage").href = `http://localhost:5501/index.html?auth=${new URLSearchParams(location.search).get("auth")}`

    document.getElementById("hotel").href = `http://localhost:5501/categories.html?type=Hotel&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("cafe").href = `http://localhost:5501/categories.html?type=Cafe&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("fitness").href = `http://localhost:5501/categories.html?type=Fitness&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("pool").href = `http://localhost:5501/categories.html?type=Pool&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("club").href = `http://localhost:5501/categories.html?type=Club&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("mall").href = `http://localhost:5501/categories.html?type=Mall&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("track").href = `http://localhost:5501/categories.html?type=Track&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    
    document.getElementById("sauna").href = `http://localhost:5501/categories.html?type=Track&page=1&auth=${new URLSearchParams(location.search).get("auth")}`    

    console.log(data)
}



// Function to define innerHTML for HTML table
function showDestinations(data) {
    let tab = 
            `<div class="block" id="topPlaces">
            </div>`;

    for (let r = 0; r < 3; r++) {
        tab += `<div class="card">
                    <div><img src="${data[r].imageTitle}" alt="" style = "height: 200px; width: 200px"></div>
                    <div class="info">
                        <p>${data[r].name}</p>
                    </div>
                </div>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("topPlaces").innerHTML = tab;
}

function showEvents(data) {
    let tab = 
            `<div class="block" id="topEvents">
            </div>`;

    for (let r of data) {
        tab += `<div class="card">
                    <div><img src="${r.eventImage}" alt="" style = "height: 200px; width: 200px"></div>
                    <div class="info">
                        <p>${r.title}</p>
                    </div>
                </div>`;
    }
    // Setting innerHTML as tab variable
    document.getElementById("topEvents").innerHTML = tab;
}

