# speaker: Mine Drone
VAR finished_gasleak = false

Greetings. An anomaly has been detected within the operational parameters, prompting immediate attention.

* "What's the situation?"
-> AskWhatProblem
* "I'm currently occupied."
-> Ignore
* {finished_gasleak} "I've pinpointed the origin of the gas leak."
-> FoundGasLeak

=== AskWhatProblem ===

# addQuest GasLeak
An indication of a potential gas leak has surfaced within one of the tunnels. It's imperative to swiftly identify and contain it to avert any potential mishaps. Maintain vigilance and be on the lookout for any indications of gas accumulation.

-> END

=== Ignore ===

Acknowledged. Inform me of any alterations in the situation.
-> END

=== FoundGasLeak ===

# removeQuest GasLeak
Mine Drone: Commendable work. Provide the precise location promptly for containment protocols.
-> END