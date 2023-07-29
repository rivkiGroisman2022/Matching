const donationsUrl = 'http://localhost:5296/api/'; 
document.addEventListener('DOMContentLoaded', onDomLoaded);
function onDomLoaded() {
    GetAllDonations();
    document.getElementById('newDonation').addEventListener('submit', postDonation)
   // GetCoursesList();
   // document.getElementById('newCourse').addEventListener('submit', addNewCourse)
}

async function GetAllDonations() {
  await  fetch(`${donationsUrl}Donations`)
        .then(response => response.json())
        .then(data => {
            const ul = document.getElementById('donations');
            ul.innerHTML = ""
            data.forEach(d => {
                //console.log('Course Name:', c.courseName, 'Teacher Name:', c.teacherName)
                ul.innerHTML += `<li> donor name: ${d.donorName}, sum: ${d.sum}, date: ${d.date}, inscription: ${d.inscription}</li>`
            });
        })
        .catch(error => console.log(error));
}

async function  postDonation(e) {
    e.preventDefault();
    const donation = colectData();
  await  fetch(`${donationsUrl}Donations`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(donation)
    }).then(data => data.json())
    .then(alert("hi"))
        //.then( apt => console.log(`post Student works` ), console.log(stu))
      // .then(console.log(` ${stu} ${i}`))
        .catch(error => console.log(error));
        GetAllDonations();
}

function colectData() {
    let throwCollectorName = document.getElementById('throwCollectorName').value;
    let donorName = document.getElementById('donorName').value;
    let sum = document.getElementById('sum').value;
    let inscription = document.getElementById('inscription').value;
    let phoneNumber = document.getElementById('phoneNumber').value;
    let adress = document.getElementById('adress').value;
    let email = document.getElementById('email').value;
    let creditNumber = document.getElementById('creditNumber').value;
    let cvv = document.getElementById('cvv').value;
    let validity = document.getElementById('validity').value;
    let idnumber = document.getElementById('idnumber').value;
    let name = document.getElementById('name').value;
    document.getElementById('throwCollectorName').value = null;
    document.getElementById('donorName').value = null;
    document.getElementById('sum').value = null;
    document.getElementById('inscription').value = null;
    document.getElementById('phoneNumber').value = null;
    document.getElementById('adress').value = null;
    document.getElementById('email').value = null;
    document.getElementById('creditNumber').value = null;
    document.getElementById('cvv').value = null;
    document.getElementById('validity').value = null;
    document.getElementById('idnumber').value = null;
    document.getElementById('name').value = null;
    return {
  "DonationCommon": {
    "DonorName": donorName,
    "Sum": sum,
    "Date": new Date(),
    "Inscription": inscription
  },
  "ThrowCollectorName": throwCollectorName,
  "DonorCommon": {
    "DonorName": donorName,
    "PhoneNumber": phoneNumber,
    "Adress": adress,
    "Email": email
  },
  "CreditCard": {
    "CreditNumber": creditNumber,
    "Cvv": cvv,
    "Validity": validity,
    "Idnumber": idnumber,
    "Name": name
  }
}
}

async function updateGoal() {
    const pass = document.getElementById('password').value
    const newGoal = document.getElementById('newGoal').value
    var f=parseFloat(newGoal);
 await   fetch(`${donationsUrl}Collector/${pass}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(f)
    }).then(data => data.json())
     //   .then(apt => console.log(stud))
      //  .then(console.log(`update Student works ${stud}`))
        .catch(error => console.log(error));
 }
 