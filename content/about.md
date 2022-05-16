---
title: About Me
---

## Overview

I'm an amateur, hoping to one day be a professional, software developer.

I never graduated, or even really attended, high school, but somehow ended up in
my current status as a struggling Computer Science student at the University of
Toronto after a brief one-year stint as a Computer Engineering student at
Algonquin College.

## Profiles

### Encyclopedias

- [ArchWiki](https://wiki.archlinux.org/title/User:PotatoDiet)
- [Old School RuneScape Wiki](https://oldschool.runescape.wiki/w/User:PotatoDiet)
- [Wikipedia](https://en.wikipedia.org/wiki/User:PotatoDiet)

### Programming

- [Arch User Repository](https://aur.archlinux.org/account/potatodiet)
- [GitHub](https://github.com/potato-diet)
- [RubyGems](https://rubygems.org/profiles/potatodiet)
- [Rust Package Registry](https://crates.io/users/potato-diet)
- [Docker Hub](https://hub.docker.com/u/potatodiet)

### Social Media

- [Hacker News](https://news.ycombinator.com/user?id=potatodiet)
- [Reddit](https://www.reddit.com/user/potato-diet)

## This Site

### Technical

This website is mainly a collection of plain text Markdown files which gets
converted into HTML using [Hugo](https://gohugo.io/)
([a](/files/archive/hugo_2021-09-18.html)) and prettified using the
[Hugo Book Theme](https://github.com/alex-shpak/hugo-book)
([a](/files/archive/book-theme_2021-09-18.html)). Markdown is a very standard
format supported by most static site generators, so if for some reason I decide
to migrate away from Hugo in the future, the process should be fairly pain free.

The source code is stored in a Git repository due the familiarity I have with
Git in my day to day programming life, though in reality there's not actually
much use in using Git for what is mostly writing done only by myself. Git's main
use, along with all version control tools, is to collaborate with others and
provide a history of all changes, which isn't exactly that important for this
project.

Oracle Cloud provides a [free tier](https://www.oracle.com/ca-en/cloud/free/)
([a](/files/archive/oracle-free-tier_2022-03-29.html)) with an unbelievable 4
core 24 GB RAM ARM VPS, 200 GB storage, and 10 TB of monthly bandwidth. Surely
at some point in the future Oracle will drastically cut back their offering, but
for now I have this website,
[Gitea](https://code.potatodiet.ca/potatodiet/potatodiet.ca), and
[Drone](https://drone.potatodiet.ca/potatodiet/potatodiet.ca) hosted on a free
Oracle Cloud VPS.

Now is where Git comes in handy for this website. Each time a commit is pushed
to Gitea, Drone receives a webhook and then builds and publishes the website.
[Caddy](https://caddyserver.com/) ([a](/files/archive/caddy_2022-03-29.html)) is
then used to serve the static files. Though it's not quite useful to what will
surely be a forever low traffic website,
[Cloudflare](https://www.cloudflare.com/en-ca/)
([a](/files/archive/cloudflare_2022-03-29.html)) is used as a CDN to prevent any
sudden hugs of deaths.

## What I Use

### Desktop

Since sometime around 2014 I've been using Linux as my main operating system. I
started off with Ubuntu, and eventually after trialing all the popular
distributions, landed on Arch Linux, mostly due to the amazing Arch User
Repository. My setup has been pretty stable for the past few years. I use Sway
as my window manager, i3 is probably still for the most part better to use since
I still run into issues with Steam games on Sway, but it's acceptable.
Otherwise, I have to say that tiling window managers are the absolute best for
productivity. I truly can not imagine how computer-dependent workers manage with
the normal GUI workflow.

I use Firefox along with the extensions uBlock Origin, Bitwarden, and
Violentmonkey. The choice of browser doesn't really matter, as effectively all
the major mainstream browsers are essentially the same.

I use just a single 2560x1440 144Hz 27" monitor as I get all the benefits of a
multi-monitor setup I need, without the downsides of increased desk space usage
and head movement.

## Personality Tests

### MBTI

I don't have records, but I first performed a few MBTI tests around 2015 - 2017
and would consistently be marked as INTP, with a few tests rarely giving me
INTJ. Perhaps I'm just biased since I first was marked as INTP, but I'd classify
myself as INTP. I also would classify MBTI as 60% true on the truth-astrology
scale.

### Archives

| Website                                                         | Date       | Type      | Result                                                                      |
| --------------------------------------------------------------- | ---------- | --------- | --------------------------------------------------------------------------- |
| [8values](https://8values.github.io/)                           | 2021-10-29 | Political | [Social-Balanced-Liberal-Progressive](/files/tests/8values_2021-10-29.html) |
| [Truity](https://www.truity.com/test/big-five-personality-test) | 2021-10-27 | Big Five  | [75-60-29-37-40](/files/tests/truity-big-five_2021-10-27.html)              |
| [16Personalities](https://www.16personalities.com/)             | 2021-10-27 | MBTI      | [ISTP-A](/files/tests/16personalities_2021-10-27.html)                      |
| [Dynomight](https://dynomight.net/mbti/)                        | 2021-10-27 | MBTI      | [INTJ](/files/tests/dynomight_2021-10-27.webp)                              |
| [Political Compass](https://www.politicalcompass.org/test)      | 2021-10-26 | Political | [Libertarian Left](/files/tests/political-compass_2021-10-26.webp)          |
