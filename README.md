# Coding test XML 
  
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Task

Given a XML string and write a function to return true if the string is a valid XML string; otherwise return false. A string is a valid XML string if it satisfies the following two rules:

- Each starting element must have a corresponding ending element
- Nesting of elements within each other must be well nested, which means start first must end last. For example: 
``<tutorial><topic>XML</topic></tutorial>`` is a correct way of nesting but ``<tutorial><topic>XML</tutorial></topic>`` is not

To simplify the question, we treat a pair of a opening tag and a closing tag as matched only if the strings in both tags are identical. So we don’t need to parse extra components like attributes in the XML tag. For example, we treat`<tutorial date="01/01/2000">XML</tutorial>` as not correctly closed since the string **tutorial date=”01/01/2000”** in the opening tag is different from the string **tutorial** in the closing tag

Please write a function to determine whether or not a string is a valid XML string.
Note that any class in System.XML and Regular Expression are prohibited in this question.
Your code should include the entrypoint `bool DetermineXml(string xml)`

Example 1:
Input: `<Design><Code>hello world</Code></Design>` 
Output: true

Example 2:
Input: `<Design><Code>hello world</Code></Design><People>`
Output: false

Example 3:
Input: `<People><Design><Code>hello world</People></Code></Design>`
Output: false

Example 4:
Input: `<People age=”1”>hello world</People>`
Output: false

Inputs are not limited to these examples and could be anything. Please be mind that  your code should be a quality that's good enough for professional developers to continue working on
 
## Development Description
Solution contains 3 projects:
- App - console application
- Tests - NUnit tests for library
- XMLValidator - library with code

## DetermineXml Method Description

Complacity O(n) - in method we use only one loop FOR. 

Algorithm start analyze from checking inputs, then we create TAG stack and flag variables.
 - Variable `tags` contains only tag openers  
 - Variable `IsTagOpen` detect when algorithm hit Tag open symbole `<` and next chars will be readed as TAG untile we hit tag close symbole `>`
 - Variable `IsTagClose` detect when algorithm hit symbole `/` and inform algorithm that the next tag will tag closer 
 - Variable `tag` contains only tag string  

In loop we check string chars and when we detect TAG we place it in stack, when we detect tag closer we pop from stack last string and if they didn't equals we say that XML is not correct. When we finish process all loop we check is count of tags in stack equals 0, if yes - then everything is correct. 
  
## Test Cases
- `""`, Expected Result = false
- `"<Design><Code>hello world</Code></Design>"`,Expected Result = true
- `"<Design><Code>hello world</Code><Code>hello world2</Code><Code>hello world3</Code></Design>"`, Expected Result = true
- `"<Design><Code>hello / world</Code></Design>"`, Expected Result = true
- `"<Design><>hello world</></Design>"`, Expected Result = false
- `"<Design><Code>hello world</Code></Design><People>"`, Expected Result = false
- `"<People><Design><Code>hello world</People></Code></Design>"`, Expected Result = false
- `"<People age=”1”>hello world</People>"`, Expected Result = false
- `"<tutorial date=\"01/01/2000\">XML</tutorial>"`, Expected Result = false
- `"<a>1/12/2000</a>"`, Expected Result = true

