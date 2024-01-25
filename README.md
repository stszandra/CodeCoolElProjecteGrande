<h1 style="text-align: center;">Offer Oasis - Webshop Application</h1>

<h5 style="text-align: center;">Offer Oasis is a webshop application developed using ASP.NET Core Web API for the backend and JavaScript with React for the frontend. The project focuses on imitating a fully functional webshop, employing technologies learned during our studies at Codecool.
</h5>

## Table of Contents

- [Project Goals](#project-goals)
- [Main Technologies Used](#main-technologies-used)
- [Usage Of The Site](#usage-of-the-site)
- [Features](#features)
- [How To Get Started](#how-to-get-started)
- [Contributors](#contributors)

## Project Goals

- **Imitate Webshop Functionality:** The primary goal is to create a webshop with full functionality to showcase our knowledge.
- **Agile and Scrum Development:** The project was developed in five sprints, following Agile and Scrum methodologies to simulate real-life work conditions.

## Main Technologies Used

- **Backend:** ASP.NET Core Web API
- **Frontend:** JavaScript (React) and CSS (Tailwind)
- **Database:** Dockerized MSSQL
- **CI/CD:** GitHub Actions

## Usage Of The Site

Our design aims to cater to various needs in the online retail services space:

- Users can register an account and log in to browse items on the site.
- Authentication is handled through JWT tokens.
- Item listings are loaded onto the website from the database.
- Items can be only added to the cart when the user is authenticated.
- The products in the cart are stored for each user (even after logging out).
- There is a separate subpage for order placement where the order is summarised for the user.
- The user can either clear their cart of place the order.
- Once the order is placed it is stored in database.

## Features

- **Registration:** Microsoft.AspNetCore.Identity
- **Authentication:** Microsoft.AspNetCore.Authentication.JwtBearer
- **Communication with database:** Microsoft.EntityFrameworkCore
- **Storage of cart data at frontend:** localStorage

## How to Get Started

Feel free to reach out to any of the contributing members to request access to our repository. Please provide a brief description of why you need access. Your request should be answered within a few workdays. Once access is granted, you can clone our repository.

## Contributors

- **Backend, DevOps, Dockerization, Agile Methodologies:** [Réka Makádi](https://github.com/rekamakadi)
- **Backend, Database:** [Balázs Oltvölgyi](https://github.com/balazs-oltvolgyi)
- **Frontend:** [József Armand Varga](https://github.com/Mondi18)