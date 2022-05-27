const targetDiv = document.getElementById("form");
const btn = document.getElementById("change");
btn.onclick = function () {
  if (targetDiv.style.display == "block") {
    targetDiv.style.display = "none";
  } else if(targetDiv.style.display == "none") {
    targetDiv.style.display = "block";
  } else{
    targetDiv.style.display = "none";
  }
};