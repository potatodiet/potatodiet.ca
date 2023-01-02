---
title: My Projects
---

## CEDICT to SQLite

[CEDICT to SQLite](https://github.com/potato-diet/cedict_to_sqlite) is a python
script which downloads
[CC-CEDICT](https://www.mdbg.net/chinese/dictionary?page=cedict), a popular
Chinese to English translation database, and converts it into an SQLite
database. The script supports displaying pinyin as both character accents (á)
and number identifiers (a1).

## gazou

I've always loved the joyful experience of developing with Ruby but the poor
performance and lack of static typing is a major sore spot, luckily Crystal
exists. Crystal is basically a statically typed compiled Ruby, so it's obviously
something I'd want to use.

In June 2020, I had the brilliantly unique idea of coppying the basics of
[Catbox](https://catbox.moe/) ([a](/files/archive/catbox_2022-03-26.html)).
Quickly, I had a MVP developed which let users upload images, returning a
deduplicated URL pointing towards their image to send to others.

The source code can be viewed on [GitHub](https://github.com/potato-diet/gazou),
and a [demo](https://gazou.potatodiet.ca) is available.

## Image Board

Throughout mid-2014, I developed a danbooru-style website which lets users share
and images. Other users can then discover interesting and relevant images by
searching with community generated tags. There's also support for a per-image
commenting system along with admin roles which lets admins delete any comment or
image. The website was originally built with Rails 4, and then in 2020, updated
to Rails 6. I used Vagrant to create a consistent development environment, but
now Vagrant is basically obsolete and replaced with Docker.

The source code can be viewed on
[GitHub](https://github.com/potato-diet/image_board), and there is a
[demo](https://ib.potatodiet.ca) available.

## Media Home

Over the first few months of 2021, I developed a home media server using Go and
React. The website only supports movies as of now, through
[The Movie Database](https://www.themoviedb.org/documentation/api)
([a](/files/archive/tmdb_2021-08-25.html)). There is a rudimentary search
ability, where the user can search by partial title matching. The videos are
played through the default HTML5 video player, and there is basic support for
resuming video playback as the website saves the current timestamp every 5
seconds. There's no support for login, or multi-user access, so anyone can
access all parts of the website and the resume timestamp is shared among all
viewers.

The source code can be viewed on
[GitHub](https://github.com/potato-diet/media_home), and there is a
[demo](https://mh.potatodiet.ca) available.

## Mood

On 18 March 2021, I developed a quick little website which takes your 50 most
recently played Spotify songs and compares them to the
[Top 50 - Global](https://open.spotify.com/playlist/37i9dQZEVXbMDoHDwVN2tF)
playlist, showing you how your listening habits compare to the norm for energy,
happiness, and danceability. The website is very simple with a basic UI, and was
just built to help me understand a few things about React. The demo is also
hosted with Cloudflare Pages which is a pretty simple and seamless process which
I'd recommend using.

The source code can be found on [GitHub](https://github.com/potato-diet/mood),
and a [demo](https://mood.potatodiet.ca) is available.

## Open World Prototype

Around 2015, before starting College when I was completing my GED, me and a
friend began developing a game with Unity. It was meant to be an open world game
where you can go around destroying objects, collecting resources, and building
tools and structures. Before discontinuing development, we implemented
pathfinding where a tic-tac-like object follows you around, an inventory system
where you can pick up a pickaxe / regular axe and select between the two with
your number keys, and the ability to chop down trees by clicking on their base
with the axe in your hand.

### Downloads

- [Windows](/files/open-world/windows.zip)
- [Mac](/files/open-world/mac.zip)
- [Linux](/files/open-world/linux.zip)
- [Online](/files/open-world/webgl/index.html)

## UofT Tools

[UofT Tools](https://github.com/potato-diet/uoft-tools) is a collection of
scripts which I've developed since beginning undergraduate studies to help with
various tasks at UofT. Once I graduate, they'll propably go unmaintained and
become of little use.

Currently there's two tools:

- UofT Prof Ratings - A webextension which adds ratemyprof.com info to the
  course selection websites.
- Course Finder - A python script which lets you fill in which courses you've
  taken and then gives you a list of courses you're able to enroll in.
