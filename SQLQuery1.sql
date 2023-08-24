select *
from actor a
	inner join film_actor x on x.actor_id = a.actor_id
where x.film_id = 1