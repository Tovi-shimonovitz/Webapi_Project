const uri = "User/Login"


function get() {

    const addNameTextbox = document.getElementById('nameId');
    const addPwrdTextbox = document.getElementById('pwrdId');

    const user = {

        Name: addNameTextbox.value.trim(),
        password: addPwrdTextbox.value.trim()
    };

fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
 
    .then(response =>  response.json())
    .then(data => {
        console.log('Token:', data);
        localStorage.setItem("user",data)
      const currentUrl = window.location.href; // מקבל את ה-URL הנוכחי
        const newUrl = currentUrl.substring(0, currentUrl.lastIndexOf('/')); // מסיר את הקטע האחרון
        console.log(newUrl+'/login.html');
        window.location.href = newUrl+'/index.html';
    })
    .catch(error => {
        console.error('There has been a problem with your fetch operation:', error);
    });
     
       console.log(response)
   
}


