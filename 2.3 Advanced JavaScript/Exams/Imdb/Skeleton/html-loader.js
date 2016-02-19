var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);

				var movieNodes = Array.prototype.slice.call(moviesContainer.firstElementChild.childNodes);


				movieNodes.forEach(function (movieLi) {
					var movies = genre.getMovies(),
						movieId = movieLi.getAttribute('data-id'),
						movie = movies.filter(function (movie) {
							return Number(movie._id) === Number(movieId);
						})[0];

					movieLi.addEventListener('click', function (ev) {
						detailsContainer.innerHTML = '';
						console.log(5555);
						detailsContainer.appendChild(addActors(movie));
						detailsContainer.appendChild(addReviews(movie));
					})
				});

				var deleteButtons = Array.prototype.slice.call(moviesContainer.getElementsByClassName('delete-button'));
				console.log(moviesContainer.firstElementChild);
				deleteButtons.forEach(function (button) {
					button.addEventListener('click', function () {
						var movieToDelete = genre.getMovies().filter(function (movie) {
							return  Number(movie._id) === Number(button.parentNode.getAttribute('data-id'));
						})[0];
						console.log(button.getAttribute('data-id'));
						genre.deleteMovie(movieToDelete);
						//console.log(666666);
						moviesContainer.firstElementChild.removeChild(button.parentNode);
					});
				})
			}
		});
	}

	function addActors(movie) {
		var actorsDiv = document.createElement('div');
		actorsDiv.innerHTML += '<h2>Actors</h2>';
		var ul = document.createElement('ul');
		movie.getActors().forEach(function (actor) {
			var li = document.createElement('li');
			var actorName = document.createElement('h3');
			actorName.innerHTML = actor.name;
			var bio = document.createElement('p');
			bio.innerHTML = '<strong>Bio:</strong>' +  actor.bio;
			var born = document.createElement('p');
			born.innerHTML = '<strong>Born:</strong>' +  actor.born;
			li.appendChild(actorName);
			li.appendChild(bio);
			li.appendChild(born);
			ul.appendChild(li);
		});

		actorsDiv.appendChild(ul);

		return actorsDiv;
	}

	function addReviews(movie) {
		var reviewsDiv = document.createElement('div');
		reviewsDiv.innerHTML += '<h2>Reviews</h2>';
		var ul = document.createElement('ul');
		movie.getReviews().forEach(function (review) {
			var li = document.createElement('li');
			var reviewName = document.createElement('h3');
			reviewName.innerHTML = review.name;
			var bio = document.createElement('p');
			bio.innerHTML = 'Bio:' +  review.bio;
			var born = document.createElement('p');
			born.innerHTML = 'Born:' +  review.date;
			var deleteButton = document.createElement('button');
			deleteButton.innerHTML = 'Delete review';
			deleteButton.addEventListener('click', function (ev) {
				movie.deleteReviewById(review._id);
				ul.removeChild(li);
			});

			li.appendChild(reviewName);
			li.appendChild(bio);
			li.appendChild(born);
			li.appendChild(deleteButton);
			ul.appendChild(li);
		});

		reviewsDiv.appendChild(ul);

		return reviewsDiv;
	}


	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			var deleteButton = document.createElement('button');
			deleteButton.innerHTML = 'Delete movie';
			deleteButton.className = 'delete-button';
			liMovie.appendChild(deleteButton);
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	scope.loadHtml = loadHtml;
}(imdb));