# speaker: Astronaut
VAR finished_passport = false

There's been a mishap.

* "What's the situation?"
-> AskWhatHappened
* "I'm not interested."
-> Ignore
* {finished_passport} "I've located the passport."
-> FoundPassport

=== AskWhatHappened ===
# addQuest FindPassport
One of our crew members lost their passport during the chaos. We need to find it before we can proceed with any further plans. Keep an eye out for any clues amidst the wreckage.

-> END

=== Ignore ===
Suit yourself. Let me know if you change your mind.
-> END

=== FoundPassport ===

removeQuest FindPassport
Excellent work. Hand it over to me.
-> END