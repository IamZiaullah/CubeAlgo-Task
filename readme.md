# LetsBuild Technical (Algorithm) Test:

You are given a box with integer dimensions length x width x height. You also given a set
of cubes whose sides are powers of 2, e.g. 1x1x1, 2x2x2, 4x4x4 etc.
You need to fill the box with cubes from the set.
Write a program that for a given box and given set of cubes can determine the smallest
number of cubes needed to fill the box.
The set of cubes can be represented for instance as a list or array of numbers, where
the position in the list designates the dimension of the cube. E.g. 100 10 1 means you
have 100 cubes of 1x1x1 and 10 cubes of 2x2x2 and 1 cube of 4x4x4.
A problem specification is a sequence of lines separated by newline. Each line has the
box dimensions as the first three elements and the remaining elements enumerate the
given cubes. Elements are separated by a single space. Lines are terminated by your
platform’s newline convention.

1

For example
2 3 4 5 6
7 8 9 1 2 3 4
specifies two problems:
- a box with dimensions 2 x 3 x 4, 5 cubes of 1x1x1 and 6 cubes of 2x2x2
- a box with dimensions 7 x 8 x 9, 1 cube of 1x1x1, 2 of 2x2x2, 3 of 4x4x4, and 4
of 8x8x8.
Your program should read one or more problem specifications from stdin and print the
answer to each problem on stdout. Spend as little effort as possible on parsing and
validation of the input. An unsolvable problem should yield -1. Please provide
instructions on how to run / compile your program. Your program should handle the
cases in the example below. If it fails on any of the problems, please indicate this in your
submission.

# How to Run the program:

Since i wasn't bound to a specific programming language, I chose C# on top of .Net 6 so to run this program you need to have visual studio with .net 6 sdk installed.
- Open the .sln file and run the program.

# How to Pass Test Data.

since i used Console.ReadToEnd() function of .net Console app
you can enter multiline string. to get to new line you press enter and so on. now if you have entered all the data and want to process it press enter to get to the new line and then press 'CTRL+Z' it will show something like Z^ this and then press enter.

# Provided Test Data Result

I was provided the test data in the task description 
10 10 10 2000
10 10 10 900
4 4 8 10 10 1
5 5 5 61 7 1
5 5 6 61 4 1
1000 1000 1000 0 0 0 46501 0 2791 631 127 19 1
1 1 9 9 1

and it's result was provided 

1000
-1
9
62
59
50070
9

when i ran the algo with test data i got
-1
9
13
59
50070
2

all the data matched except for these two

1 1 9 9 1   result i got = 2 : provided test data result = 9.
5 5 5 61 7 1 result = 13 : provided test data result  = 62.

I thought there might be some issue with the program and debugged the logic but when i debugged since the first three numbers are diamentions of the box
so for 1 1 9 9 1
the box is 1X1X9 which's vol will be 9 and the cubes we got are 9 cubes of 1X1X1 which's vol is 1 and 1 cube of 2X2X2 which's vol is 8 
- to fill the box we have to find combo of cubes that gives us 9 vol and that is 1 2X2X2 cube and 1 8X8X8 cube. so the answer according to my solution is 2 and it was right.
- now this might be my misunderstanding of the problem at hand or the test data has some issue.

- I debugged for 5 5 5 61 7 1 and it was the same problem.


