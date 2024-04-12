VAR finished_passport = false

Astronaut: There's been a mishap.

* "What's the situation?"
-> AskWhatHappened
* "I'm not interested."
-> Ignore
* {finished_passport} "I've located the passport."
-> FoundPassport

=== AskWhatHappened ===
# addQuest FindPassport
Astronaut: One of our crew members lost their passport during the chaos. We need to find it before we can proceed with any further plans. Keep an eye out for any clues amidst the wreckage.

-> END

=== Ignore ===
Astronaut: Suit yourself. Let me know if you change your mind.
-> END

=== FoundPassport ===

removeQuest FindPassport
Astronaut: Excellent work. Hand it over to me.
-> END