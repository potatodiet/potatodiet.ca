---
title: "A Tale of Docker & Windows"
published: false
---

While working at SOTI, I was tasked with integrating Docker into our CI process.
This is an overview of my painful experience doing so.

My first large project during my internship was to develop a CI pipeline to
track the security of our main product. This would involve both static and
dynamic analysis.

Static analysis involved actions such as integrating SonarQube into the backend
build step to track insecure code or performing 'yarn audit' to check for out of
date frontend packages. These were fairly simple.

Dynamic analysis for us involved running OWASP ZAP against a live instance of
our main product each day. ZAP is a penetration testing tool, so this meant that
the instance would be getting hammered with millions of requests which results
in an abundence of state being created which sticks around unless we create a
fresh instance each time. This was a much harder problem as we didn't have any
system for easily automating truly independent instances. I'd have to change
that.

We had an existing system for our integration tests which involved having our
product installed persistently on a few build nodes, and during each integration
test step we'd stop and start the processes as needed along with cleaning up the
database as the steps were completed. This system was fine enough but too
brittle for my goal of running a daily penetration test with OWASP ZAP.
