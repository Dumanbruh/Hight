var form  = document.querySelector('.signUp');
var validateBtn = form.querySelector('.validateBtn');
var firstName = form.querySelector('.firstName');
var lastName = form.querySelector('.lastName');
var email = form.querySelector('.email');
var password = form.querySelector('.password');
var fields = form.querySelectorAll('.field')

var generateError = function (text) {
	var error = document.createElement('div')
	error.className = 'error'
	error.style.color = 'red'
	error.innerHTML = text
	return error
}

var removeValidation = function (){
	var errors = form.querySelectorAll('.error')

	for (let index = 0; index < errors.length; index++) {
		errors[index].remove()
	}
}

/*
var insertAfter = function (referenceNode, newNode) {
	referenceNode.parentElement.insertBefore(newNode, referenceNode.nextSibling);
}
*/

/*
var checkFieldsPresence = function (){
	for (let index = 0; index < fields.length; index++) {
		if(!fields[index].value){
			console.log('field is blank', fields[index])
			var error = generateError('This value is required.')
		   form[index].parentElement.insertBefore(error, fields[index])
		}
	}
}
*/
form.addEventListener('submit' , function (){
	event.preventDefault();
	
	removeValidation()
	
	//checkFieldsPresence();
})