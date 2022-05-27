var ctx = document.getElementById('myChart').getContext('2d');
const chart = new Chart(ctx, {
	type: 'bar',
	
	data : {
		labels: [5, 4, 3, 2, 1],
		datasets: [{
		  axis: 'y',
		  label: 'My First Dataset',
		  data: [65, 59, 80, 81, 56, 55, 40],
		  fill: false,
		  backgroundColor: [
			 'rgba(255, 99, 132, 0.2)',
			 'rgba(255, 159, 64, 0.2)',
			 'rgba(255, 205, 86, 0.2)',
			 'rgba(75, 192, 192, 0.2)',
			 'rgba(153, 102, 255, 0.2)',
			 'rgba(153, 102, 255, 0.2)',
			 'rgba(201, 203, 207, 0.2)'
		  ],
		  borderColor: [
			 'rgb(255, 99, 132)',
			 'rgb(255, 159, 64)',
			 'rgb(255, 205, 86)',
			 'rgb(75, 192, 192)',
			 'rgb(54, 162, 235)',
			 'rgb(153, 102, 255)',
			 'rgb(201, 203, 207)'
		  ],
		  borderWidth: 0.1
		}]
	},
	options: {
		responsive: true,
		maintainAspectRatio: false,
		indexAxis:  'y',
		 scales: {
			  y: {
					beginAtZero: true
			  }
		 }
	}
});

