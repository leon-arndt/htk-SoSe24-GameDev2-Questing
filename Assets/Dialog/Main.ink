# speaker: Slim
VAR completable_computer = false
VAR completed_computer = false

Hello detective.
* {completed_computer} "Can I help with anything else?"
    -> AfterFinish
* {not completed_computer} "What happened boss?"
    -> FirstTime

=== AfterFinish ===
Not right now. I will let you know if I need anything else.
-> END


=== FirstTime ===
There was an accident.

* "What did you see?"
    -> AskWhatSee
* "I don't care"
    -> Cancel
* {completable_computer} "I found the computer"
    -> FoundComputer

=== AskWhatSee ===
# addQuest Computer
Two space ships crashed into each other. There was a corrupt business man on that ship. Collect his briefcase computer as evidence so we can put that thug behind bars. Be careful of the corrupt police drones.

-> END

=== Cancel ===
Talk to me again when you do care.
-> END

=== FoundComputer ===
# completeQuest Computer
Good job. I'll take that from you.
    -> END
