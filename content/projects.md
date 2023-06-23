---
title: My Projects
---

## Overview

- [CinemaCentral](https://github.com/potatodiet/CinemaCentral) - Lightweight
  website for streaming home media. (C#, TypeScript)
- [Homebrew Tweego](https://github.com/potatodiet/homebrew-tweego) - Homebrew
  tap for Tweego, a compiler for Twine stories. (Ruby)
- [Diceware Gen](https://github.com/potatodiet/diceware-gen) - Diceware
  generator. (Rust)
- [Potato Tools](http://github.com/potatodiet/PotatoTools) - Collection of
  browser-accessible tools. (JavaScript)
- [Anki Chinese Helper](https://github.com/potatodiet/anki_chinese_helper) -
  Helper add-on for Anki to make studying Chinese simpler. (Python)
- [CEDICT to SQLite](https://github.com/potatodiet/cedict_to_sqlite) - Convert
  CEDICT into a SQLite database. (Python)
- [Mood](https://github.com/potatodiet/mood) - Compare your music tastes with
  the global average. (JavaScript)
- [UofT Tools](https://github.com/potatodiet/uoft-tools) - Tools which proved
  useful during my bachelor's degree. (Python, TypeScript)
- [Image Board](https://github.com/potatodiet/image_board) - Danbooru-style
  image board. (Ruby, HAML)
- [Documentaries](https://github.com/potatodiet/documentaries) - Share YouTube
  documentaries. (Ruby, HAML)
- [Teamspeak Ruby](https://github.com/potatodiet/teamspeak-ruby) - Client
  library for TeamSpeak 3's server query API. (Ruby)
- [Teamspeak Python](https://github.com/potatodiet/python-teamspeak) - Client
  library for TeamSpeak 3's server query API. (Python)
- [Gazou](https://github.com/potatodiet/gazou) - Direct image sharing website.
  (Crystal)
- [GPA Calculator](https://github.com/potatodiet/gpa_calculator) - Course grades
  tracker. (Haskell)
- [Tsuno](https://github.com/potatodiet/tsuno) - Course grades tracker. (Ruby)
- [Gem Tracker](https://github.com/potatodiet/gemtracker) - Track the daily
  install rate of RubyGems.org gems. (C++)
- [Autoplete](https://github.com/potatodiet/autoplete) - Add autocompletion to
  input tags. (JavaScript)
- [Simple Server](https://github.com/potatodiet/SimpleServer) - HTTP server.
  (C++)
- [Rokunet](https://github.com/potatodiet/rokunet) - Networking library. (C++)
- [Dacado](https://github.com/potatodiet/dacado) - Encode arbitrary data into
  images. (Java)
- [AverageFrame](https://github.com/potatodiet/AverageFrame) - Display the
  average frame of a video. (Java)
- [Bitsu](https://github.com/potatodiet/bitsu) - URL router. (C++)
- [Book Sorter](https://github.com/potatodiet/book_sorter) - Sort books into
  folders following the Dewey Decimal System. (Ruby)
- [Nero](https://github.com/potatodiet/nero) - Web framework. (JavaScript)

## Homebrew Tweego

- [GitHub](http://github.com/potatodiet/homebrew-tweego)

A Homebrew tap containing a formulae for Tweego, a compiler for Twine stories.

This will most likely remain a Homebrew tap. I attempted to include this into
Homebrew Core but couldn't resolve a few structural issues.

Without indending to critizise, Tweego works in an odd way. Twine stories
support customized functionality through story formats. Each story requires one
story format to inherit from. Story formats are developed by third parties with
their own seperate licenses and build steps. Tweego comes prepackaged with a few
of the most popular story formats. When you run Tweego, it expects to find a
folder with these story formats. If it doesn't find this folder, then it exits
early. Even 'tweego --version' exits early.

For inclusion in Homebrew Core, formulae are required to wholly build from
source, which means those prepackaged third party story formats must either by
excluded or compiled as well. Since Tweego can't be used without a story format,
exclusion isn't an option. Since these story formats are all seperate projects,
they also shouldn't be included in the Tweego formula. I thought of creating
formulae following the naming scheme twine-storyformat (Ex: twine-sugarcube).
This has a critical error though: Tweego searches specific locations for a
singular storyformats folder, which contains a list of story formats. I couldn't
figure out a way to install all these twine-storyformat formulae to a singular
location. I also thought it was wrong to package all these story formats into
one formula.

Perhaps I could patch Tweego to perform basic functionality without finding a
storyformats folder, which would fix the formula validation issue. I don't see
any simple way to include story formats in Homebrew, so I'd most likely need
users to download those themselves, which isn't optimal.

## Diceware Gen

- [GitHub](https://github.com/potatodiet/diceware-gen)
- [AUR](https://aur.archlinux.org/packages/diceware-gen)

Diceware is a technique for generating random passphrases. Traditionally you'd
roll five dice, record the upward faces (Ex: 12345), lookup your result in a
7776-length wordlist (Ex: 12345 -> arousal using EFF's Large Wordlist), repeat
as desired. This is a Rust program which performs diceware programmatically.

This was useful to me when I used password-gen to store passwords. After
migrating to Bitwarden, and now 1Password, I don't have need of this anymore.

## Potato Tools

- [GitHub](https://github.com/potatodiet/PotatoTools)
- [Live](https://tools.potatodiet.ca)

A collection of tools which solve common issues I have. One example is when I
want to losslessly compress many PNGs to WebP, but don't want to mess around
with the terminal.

## CEDICT to SQLite

[CEDICT to SQLite](https://github.com/potatodiet/cedict_to_sqlite) is a python
script which downloads
[CC-CEDICT](https://www.mdbg.net/chinese/dictionary?page=cedict), a popular
Chinese to English translation database, and converts it into an SQLite
database. The script supports displaying pinyin as both character accents (á)
and number identifiers (a1).

## gazou

- [GitHub](https://github.com/potatodiet/gazou)

I've always loved the joyful experience of developing with Ruby but the poor
performance and lack of static typing is a major sore spot, luckily Crystal
exists. Crystal is basically a statically typed compiled Ruby, so it's obviously
something I'd want to use.

In June 2020, I had the brilliantly unique idea of coppying the basics of
[Catbox](https://catbox.moe/) ([a](/files/archive/catbox_2022-03-26.html)).
Quickly, I had a MVP developed which let users upload images, returning a
deduplicated URL pointing towards their image to send to others.

## Image Board

- [GitHub](https://github.com/potatodiet/image_board)

Throughout mid-2014, I developed a danbooru-style website which lets users share
and images. Other users can then discover interesting and relevant images by
searching with community generated tags. There's also support for a per-image
commenting system along with admin roles which lets admins delete any comment or
image. The website was originally built with Rails 4, and then in 2020, updated
to Rails 6. I used Vagrant to create a consistent development environment, but
now Vagrant is basically obsolete and replaced with Docker.

## Media Home

- [GitHub](https://github.com/potatodiet/media_home)

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

## Mood

- [GitHub](https://github.com/potatodiet/mood)
- [Demo](https://mood.potatodiet.ca)

On 18 March 2021, I developed a quick little website which takes your 50 most
recently played Spotify songs and compares them to the
[Top 50 - Global](https://open.spotify.com/playlist/37i9dQZEVXbMDoHDwVN2tF)
playlist, showing you how your listening habits compare to the norm for energy,
happiness, and danceability. The website is very simple with a basic UI, and was
just built to help me understand a few things about React. The demo is also
hosted with Cloudflare Pages which is a pretty simple and seamless process which
I'd recommend using.

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

- [GitHub](https://github.com/potatodiet/uoft-tools)

A collection of scripts which I've developed since beginning undergraduate
studies to help with various tasks at UofT. Once I graduate, they'll propably go
unmaintained and become of little use.

Currently there's three tools:

- UofT Prof Ratings - A webextension which adds ratemyprof.com info to the
  course selection websites.
- Course Finder - A Python script which lets you fill in which courses you've
  taken and then gives you a list of courses you're able to enroll in.
- Course Archive - A Ruby script which downloads all syllabi from the
  Mississauga campus. [Archive](/files/uoft/utm-syllabi.tar.zst) as of 2023
  summer.
