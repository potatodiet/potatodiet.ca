---
title: Media Home
---

## Description
Over the first few months of 2021, I developed a home media server using Go and React. The website only supports movies as of now, through [The Movie Database](https://www.themoviedb.org/documentation/api) ([a](/files/archive/tmdb_2021-08-25.html)). There is a rudimentary search ability, where the user can search by partial title matching. The videos are played through the default HTML5 video player, and there is basic support for resuming video playback as the website saves the current timestamp every 5 seconds. There's no support for login, or multi-user access, so anyone can access all parts of the website and the resume timestamp is shared among all viewers.

## Access
The source code can be viewed on [GitHub](https://github.com/potato-diet/media_home), and there is a [demo](https://mh.potatodiet.ca) available.
