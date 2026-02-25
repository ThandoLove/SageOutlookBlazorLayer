Office.onReady(() => {
    const btn = document.getElementById("btnSend");
    if (btn) {
        btn.onclick = sendEmail;
    }
});

function sendEmail() {
    const item = Office.context.mailbox.item;

    // Correct way to get the body asynchronously
    item.body.getAsync(Office.CoercionType.Text, async (result) => {
        if (result.status === Office.AsyncResultStatus.Succeeded) {
            const bodyText = result.value;

            const emailData = {
                subject: item.subject,
                body: bodyText,
                from: item.from ? item.from.emailAddress : "Unknown",
                // Accessing recipients carefully
                toRecipients: item.to ? item.to.map(r => r.emailAddress) : [],
                conversationId: item.conversationId
            };

            try {
                const response = await fetch("https://yourserver/api/email/process", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(emailData)
                });
                console.log("Server responded:", await response.text());
            } catch (error) {
                console.error("Fetch error:", error);
            }
        } else {
            console.error("Failed to get body:", result.error.message);
        }
    });
}
