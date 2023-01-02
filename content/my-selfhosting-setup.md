---
title: "My Homelab"
date: 2021-11-20
tags:
  - Homelab
summary: A brief overview of the different services running on my homelab.
---

For the past 5 years, I've been running a personal home media server. Without
focusing on the typical reasons for running a media server, I want to discuss
just how mine is set up and perhaps why I made certain choices.

The most basic requirement of my homelab is for the ability to watch tv shows
and movies, anything else only exists to serve that purpose or for the pure joy
of architecting an elaborate system.

I use the following user-facing programs on my Homelab:

- Jellyfin
- Ombi
- Bitwarden
- Sonarr
- Radarr
- qBittorrent
- Jackett
- Gitea

Jellyfin is a great open-source media organizer which presents your tv shows and
movies for viewing using a browser or tv in a pretty nice and clean manner. You
create libraries that contain specific types of media. For example, I have a TV
Shows library and Movies library. You then create user accounts and give each
account access to whichever libraries you want. The libraries automatically scan
for new media added to their folders, and grab all the proper metadata from
websites like The Movie DB to make things look nice. The only problem I find is
that, at least with my system, playing HEVC videos is essentially impossible.
Safari is supposed to be able to natively play HEVC, which I've successfully
tested with another Jellyfin alternative called Plex, but Jellyfin just forces
transcoding to H.264 which grinds my server's cpu to a halt. Otherwise, Jellyfin
in fine and easy enough for non-technical end-users to work with.

Ombi is used to let non-technical end-users add new tv shows and movies to a
homelab's media collection. It works with Sonarr / Radarr to download any media
a user selects for tracking through the app. By default, user requests have to
be approved by an admin account, but you can also let specific users requests be
automatically approved. Ombi works, but it's pretty ugly and not great to work
with.

Bitwarden is a password manager similar to Last Pass but completely open source
and self-hostable. The UI isn't great for non-technical users as my girlfriend
can attest to, but it's good enough for me at least.

Sonarr is a commonly used program used for automatically downloading tv shows in
conjunction with any torrent client and another popular program, Jackett, which
acts as an API for many different torrent tracker websites. To use Sonarr, you
just login, search for any tv show, select your show, and then just enable
whichever seasons you want monitored. Sonarr then automatically communicates
with your attached Jacket instance to find the required .torrent files, and
sends the files to your attached torrent client (qBittorrent in this case).
After the torrents are finished downloading, Sonarr copies the video files over
to whatever output directory was set, while making sure to rename them in the
proper format for Jellyfin or Plex to parse. As new episodes are released,
Sonarr will automatically go through that whole process to keep things up to
date.

Radarr is just a fork of Sonarr which acts exactly the same but with the purpose
of downloading movies.

qBittorent is a great torrent client. Before, I used to use Deluge, but the web
ui is terrible and very slow. I specifically don't like that you can't search
through your torrents using the web ui, however, with qBittorent you easily can.
I highly recommend using qBittorent.

Gitea is basically a self hosted GitHub clone. I don't really have much use for
Gitea, but since it's built with Go, it uses almost no system resources so it's
fine to have just sitting here just in case.

A dashboard to my homelab can be found at [LibreByte](https://librebyte.ca).
