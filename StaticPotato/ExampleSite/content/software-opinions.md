---
title: "Software Opinions"
---

## Validation

- E-mail address validation is commonly thought to be a difficult problem. One
  way people solve this seemingly difficult problem is through the use of an
  arcane regex in an attempt to predict if the user's input is a valid e-mail
  address. Don't do this. The solution is much simpler: send the user an e-mail.
  If the user receives the e-mail, they entered a valid e-mail address. It's
  fine to perform a soft validation with regex if you desire. However, only hint
  to the user that their input may be an invalid e-mail address, don't prevent
  them from continuing.

## YAML

- Use quotes around all strings. YAML parsers perform implicit typing. This
  allows for the value hello and "hello" to both be represented as a string.
  This is fine by itself, however, a problem arises with other values: no is
  represented as a False boolean. You may want the "no" string in your YAML
  configuration file, but you'll get a boolean unexpectedly instead.
  Read: [The yaml document from hell](https://ruudvanasseldonk.com/2023/01/11/the-yaml-document-from-hell)