---
title: My Time at the University of Toronto
---

An in-progress overview of the courses I took at UofT.

### CSC108 - Introduction to Computer Programming

- Fall 2018

The first semester introductory computer science course designed to teach us how
to program. I already was fairly profecient at programming and so don't really
remember anything noteworthy about the course.

### CSC148 - Introduction to Computer Science

- Sadia Sharmin
- Winter 2019

This course used a "flipped classroom" aproach where we sat in tables of 5-6
people and had roughly 10 minutes of instruction given at the start of class,
then given worksheets to complete.

Literally nothing was learned through active teaching and so honestly the
professor didn't need to exist. While we were working on the worksheets, TAs
would walk around and help us as needed. It seemed more like a ramped up
tutorial rather than lecture.

The actual tutorials were also rather unimportant. Most could be completed
quickly but we had to attend to receive participation marks.

As an aside, every tutorial we'd have the classroom partially full of students
from the previous students which was rather annoying. The room was already at
capacity, and so it made it difficult to find seats let alone good seats. Our TA
seemed to have known many of the straggling students from the previous tutorial
and so wouldn't explicitly kick them out. We'd wait outside the room as the
previous students made it seem like our tutorial hadn't started yet, and our TA
would tell us to "come on in", not knowing we were waiting outside for a reason.

The assignments in my opinion were mostly annoying and focused too much on minor
details, obscuring real learning.

### CSC369 - Operating Systems

- Bogdan Simion
- Fall 2020

The course title suggests you'll finish the semester with the knowledge of how
to write an operating system, instead you'll simply gain a disjoint
understanding of how memory paging, threading, and file systems are implemented.

Most of the assignments were unchanged from previous years which I find lazy.
Seeing GitHub repositories from 3 years ago which implement our current
semester's assignments make me think of the course as a MOOC.

All of the assignments were written in C. It always sucks to write C. Strings
being char\* is absolutely awful.

Out of four assignments, the two I remember had us implement a syscall and a
[FUSE](https://en.wikipedia.org/wiki/Filesystem_in_Userspace)-like
implementation of ext2.

To implement our syscall, we hijacked an existing rarely used syscall which is
definitely a bad practice. Since the assignments seemed to be similar to
previous years, it would've been best if the professor invested time into
writing the scafolding for us to compile a syscall the proper way. I don't like
it when professors take shortcuts when designing assignments.

Our ext2 assignment was surprisingly very interesting. We wrote a CLI
application which lets a user interact with an ext2 formatted file. Before
taking the course, the idea of implementing a file system seemed insurmountable.
Now I'm very comfortable knowing I can write a file system if needed.

### CSC236 - Introduction to the Theory of Computation

- Michael Miljanovic
- Fall 2021

I'm naturally not good at solving algorithm questions which made this course a
bit of a slog which I was lucky to pass.

I think it was the professor's first semester teaching but overall I mostly
liked his instruction.

After spending way too much time on the first problem set, I reached out to a
random person on Reddit who was looking for a partner and ended up grouping with
him and someone else he knew. He ended up doing absolutely no work on any of the
problem sets and his friend barely did any either, so it was kind of a waste to
partner up.

### CSC363 - Introduction to the Theory of Computability

- Mohammad Mahmoud
- Winter 2022

The main thing I learned from this course was the basics of complexity theory
and specifically what the different complexity classes were and how they related
to each other. I found that I'd understand the topics as we were being
instructed, but would find it difficult to solve the problems on assignemnts and
tests.

One thing I remember from the course was proving that one problem had a certain
complexity which was done by taking a problem with a known complexity such as
3SAT (NP-Complete) and then creating a bijection between the problem and 3SAT. I
understood the idea of this, but for me it was hard to know how to find the
bijections for arbitrary problems.

I was lucky to pass the course. I knew beforehand that I wasn't good at CS
theory and this course confirmed so.

### CSC324 - Principles of Programming Languages

- Lisa Zhang
- Fall 2022

The main purpose of this course was to learn about interpreters through a
functional lens. Through assignments we created an interpreter for a lisp-like
languages named Yumyscript in both Racket and Haskell, and developed a
typechecker for another custom language using Racket.

Before starting the course, I used Haskell and liked to program in an immutable
by default mindset, plus had used Common Lisp (similar to racket) so I wasn't
going in blind.

The biggest thing I learned from the course was that pattern matching +
recursion is a perfect fit for interpreters. The biggest thing I hated from the
course was continuation passing style (reminded me of callbacks but even worse)
and relational programming using miniKanren.

In my opinion, too much of the assignment grades were test cases on small
unimportant easily forgetable or ambiguous requirements.

Overall I felt that the course was alright and I learned some cool functional
programming techniques for use in side projects, since there's no way I'd get
paid to use Haskell or Lisp.
