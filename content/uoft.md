---
title: My Time at the University of Toronto
---

An in-progress overview of the courses I took at UofT.

#### Semester Mapping

| Semester | Start     | End      |
| -------- | --------- | -------- |
| Winter   | January   | April    |
| Summer   | May       | August   |
| Fall     | September | December |

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

### CSC207 - Software Design

- Arnold Rosenbloom
- Fall 2019

The most important thing gained from this course was a deluge of emails which
continued to fill my inbox years after completing the course.

Outside of reading Arnold's daily emails we learned design patterns through
writing Java programs. I've never used any of the design patterns outside of the
course, I'm fairly certain that'll stay true.

Though, like most courses, not much was learned, there was one very interesting
concept learned: state machines.

Below is a state machine which converts x into a number between 0 and 5. Yes,
this could be done far simpler without state machines.

    class State:
        PositionA = 1
        PositionB = 2
        PositionC = 3

    x = *some_num*
    state = State.PositionA

    while True:
        match state:
            case State.PositionA:
                if x < 0:
                    x *= -1
                state = State.PositionB
            case State.PositionB:
                if x > 5:
                    x = 5
                state = State.PositionC
            case State.PositionC:
                break

We worked on a group project of 4 where only myself and a friend did any work.
The project was to implement reversi with a JavaFX frontend backed by an
indepentent backend.

You could play against either the computer or a human opponent. We developed a
few strategies which the computer would use against you. One of the strategies
was greedy where it would simply pick the move which gained the most points
without looking into the future. Another strategy was an O(n^n) algorithm where
it would pick the move which caused you to gain the least amount of points the
following turn, assuming you choose the best greedy option. There were other
strategies which I've forgotten.

We split the simple stategies up among the teammates and I remember one person
directly copied a loop I wrote, changing lines in a nonsensical uncompilable way
and pretending he completed his part.

The other non-friend teammate at least didn't lie to us and knew how to code.
But he completed a minimal number of tasks and later got a personal extension to
complete his tasks, leaving our submission incomplete (causing us to lose marks)
but using our code in his submission to score a higher mark. You shouldn't be
able to get a personal extension for group projects which you get graded
separately on. I know of this happening to someone in another CSC207 term. It's
such an obvious issue which would be simple to fix: backport the grade (if it's
higher) to the rest of the team.

The teammember who got a personal extension also had me tutor him and tried to
pay me with magic mushrooms.

### CSC209 - Software Tools and Systems Programming

- Ilir Dema
- Winter 2020

The first class where we began to program at a lower abstraction level. We used
C for everything.

I enjoy the simplicity of C when working on personal projects, but I find
writing spaghetti C code inevitable when working with vague requirements or
deadlines which you get from course assignments.

Out of 4 assignemnts I remember 2: one where we worked with signals and
threading, another where we wrote a instant messaging server. The first
assignment was a perfect opportunity to reinforce the learning of C. The second
seemed like a reasonable use of C, but in practice it wasn't. We learned through
practice why people don't write multithreaded multiuser UTF-8 messaging apps
with C.

This was my first experience with Ilir. I didn't interact with him much through
the course. Later on I'd come to dislike his teaching style.

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
